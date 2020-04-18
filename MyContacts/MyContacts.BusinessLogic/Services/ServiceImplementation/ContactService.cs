using System;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.DataAccess;
using MyContacts.DataAccess.Interfaces;
using MyContacts.Entities.Models;

namespace MyContacts.BusinessLogic.Services.ServiceImplementation
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IRepo<Contact> _repoContact;
        public ContactService(ILogger logger, IRepo<Contact> repoContact) : base(logger)
        {
            _repoContact = repoContact;
        }
        public Contact GetByKey(Guid? key)
        {
            var contact = _repoContact.GetById<Contact>(key);
            return contact;
        }
    }
}