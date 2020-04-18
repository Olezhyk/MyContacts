using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Results;
//using Tools.VcfProvider.VcfProvider;




using MyContacts.Services.ServiceInterfaces;

namespace MyContacts.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        #region Get Methods

        //[HttpGet]
        //public HttpResponseMessage GetByKey(Guid key)
        //{
        //    var data = _contactService.GetByKey(key);

        //    if (data == null)
        //    {
        //        return null;
        //    }

        //    var model = _contactMapper.MapContactToContactViewModel(data);

        //    return new HttpResponseMessage
        //    {
        //        Content = new ObjectContent<ContactViewModel>(model, jsonFormat),
        //        StatusCode = HttpStatusCode.OK
        //    };
        //}
        #endregion
    }
}
