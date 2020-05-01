using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyContacts.BusinessLogic.Log;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.Entities.Models;

namespace MyContacts.Controllers.MvcControllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;
        
        public ContactController(IContactService contactService)
        {
            this._contactService = contactService;
        }

        public ViewResult List()
        {
            return View(_contactService.Get());
        }
    }
}