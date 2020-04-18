using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using MyContacts.BusinessLogic.Mapper.MapperInterfaces;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.BusinessLogic.ViewModels;

//using Tools.VcfProvider.VcfProvider;


namespace MyContacts.Controllers.ApiControllers
{
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;
        private readonly IContactMapper _contactMapper;

        public ContactController(IContactService contactService, IContactMapper contactMapper)
        {
            this._contactService = contactService;
            this._contactMapper = contactMapper;
        }

        #region Get Methods

        [HttpGet]
        public HttpResponseMessage GetByKey(Guid key)
        {
            var data = _contactService.GetByKey(key);

            if (data == null)
            {
                return null;
            }

            var model = _contactMapper.MapContactToContactViewModel(data);

            return new HttpResponseMessage
            {
                Content = new ObjectContent<ContactViewModel>(model, new JsonMediaTypeFormatter()),
                StatusCode = HttpStatusCode.OK
            };
        }
        #endregion
    }
}
