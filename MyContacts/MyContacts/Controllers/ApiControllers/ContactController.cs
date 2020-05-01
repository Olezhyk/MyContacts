using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using MyContacts.BusinessLogic.Mapper;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.BusinessLogic.ViewModels;
using MyContacts.DataAccess.Interfaces;

namespace MyContacts.Controllers.ApiControllers
{
    public class ContactController : ApiController
    {
        private IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
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

            var model = ContactMapper.MapContactToContactViewModel(contact);

            return new HttpResponseMessage
            {
                Content = new ObjectContent<ContactViewModel>(model, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK
            };
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
                    
                    contact = ContactMapper.MapEditContactViewModelToEntity(model, contact);

                    contactService.Save(contact);
                    
                    var retModel = ContactMapper.MapContactToContactViewModel(contact);
                    
                    return new HttpResponseMessage
                    {
                        Content = new ObjectContent(typeof(ContactViewModel), retModel, new JsonMediaTypeFormatter()),
                        StatusCode = HttpStatusCode.OK
                    };
                }
                catch (Exception ex)
                {
                    //_logger.Error(ex, "An  Error Occurred During saving Contact. Error: {0}", ex.Message);
                    //_logger.Error("StackTrace: {0}", ex.StackTrace);

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
