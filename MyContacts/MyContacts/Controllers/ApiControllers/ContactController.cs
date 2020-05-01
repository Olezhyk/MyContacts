using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using MyContacts.BusinessLogic.Log;
using MyContacts.BusinessLogic.Mapper;
using MyContacts.BusinessLogic.Mapper.MapperInterfaces;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.BusinessLogic.ViewModels;
using MyContacts.DataAccess.Interfaces;
using MyContacts.VcfProvider.Extensions;
using MyContacts.VcfProvider.VcfProvider;

namespace MyContacts.Controllers.ApiControllers
{
    public class ContactController : ApiController
    {
        private readonly ILogger logger;
        private readonly IContactService contactService;

        private readonly IContactMapper contactMapper;

        public ContactController(IContactService contactService, IContactMapper contactMapper, ILogger logger)
        {
            this.contactService = contactService;
            this.contactMapper = contactMapper;
            this.logger = logger;
        }

        #region Get Methods
        [HttpGet]
        public HttpResponseMessage GetByKey(Guid key)
        {
            var contact = contactService.GetByKey(key);

            if (contact == null)
            {
                return null;
            }

            var model = contactMapper.MapContactToContactViewModel(contact);

            return new HttpResponseMessage
            {
                Content = new ObjectContent<ContactViewModel>(model, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        public HttpResponseMessage GetVCardData(Guid key, string version)
        {
            try
            {
                var contactInfo = contactService.GetByKey(key);
                if (contactInfo != null)
                {
                    var info = contactMapper.MapContactToVcf(contactInfo);

                    var fileContent = VcfProviderFactory.GetVcfInstance(version).CreateByteArray(info);

                    if (fileContent != null)
                    {
                        var fileName = info.FullName ?? "VCard";
                        string filePath = $"{fileName}.vcf";

                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Content = new StreamContent(new MemoryStream(fileContent));
                        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                        response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(filePath);
                        response.Content.Headers.ContentType =
                            new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(filePath));

                        return response;
                    }

                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new ObjectContent(typeof(String), ex.Message, new JsonMediaTypeFormatter()),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAddressData(Guid key)
        {
            try
            {
                var contact = contactService.GetByKey(key);
                if (contact != null)
                {
                    var info = contactMapper.MapContactToVcf(contact);

                    var stringData = info.GetVcfAddress();

                    if (!string.IsNullOrEmpty(stringData))
                    {
                        return new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new ObjectContent(typeof(string), stringData, new JsonMediaTypeFormatter())
                        };
                    }

                    return new HttpResponseMessage(HttpStatusCode.NoContent);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new ObjectContent(typeof(String), ex.Message, new JsonMediaTypeFormatter()),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

        #endregion

        #region Post Methods

        [HttpPost]
        public HttpResponseMessage Edit(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contact = contactService.GetByKey(model.ContactKey);
                    
                    contact = contactMapper.MapEditContactViewModelToEntity(model, contact);

                    contactService.Save(contact);
                    
                    var retModel = contactMapper.MapContactToContactViewModel(contact);
                    
                    return new HttpResponseMessage
                    {
                        Content = new ObjectContent(typeof(ContactViewModel), retModel, new JsonMediaTypeFormatter()),
                        StatusCode = HttpStatusCode.OK
                    };
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "An  Error Occurred During saving Contact. Error: {0}", ex.Message);
                    logger.Error("StackTrace: {0}", ex.StackTrace);

                    return new HttpResponseMessage
                    {
                        Content = new ObjectContent(typeof(String), ex.Message, new JsonMediaTypeFormatter()),
                        StatusCode = HttpStatusCode.InternalServerError
                    };
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPost]
        public HttpResponseMessage Delete(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contactInfo = contactService.GetByKey(model.ContactKey);

                    if (contactInfo != null)
                    {
                        contactService.Delete(contactInfo);
                        
                        var retModel = new DeleteObjectResponseModel { IsSuccess = true };
                        
                        return new HttpResponseMessage
                        {
                            Content = new ObjectContent(typeof(DeleteObjectResponseModel), retModel, new JsonMediaTypeFormatter()),
                            StatusCode = HttpStatusCode.OK,
                        };
                    }

                    throw new Exception("Contact Record does not exist.");

                }
                catch (Exception ex)
                {
                    //LogActionError(ex);

                    return new HttpResponseMessage
                    {
                        Content = new ObjectContent(typeof(String), ex.Message, new JsonMediaTypeFormatter()),
                        StatusCode = HttpStatusCode.InternalServerError,
                    };
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        #endregion
    }
}
