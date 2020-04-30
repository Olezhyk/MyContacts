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
    }
}
