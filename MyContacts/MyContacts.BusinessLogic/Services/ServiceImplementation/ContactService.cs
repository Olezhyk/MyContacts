using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.DataAccess;
using MyContacts.DataAccess.Interfaces;
using MyContacts.Entities.Models;

namespace MyContacts.BusinessLogic.Services.ServiceImplementation
{
    public class ContactService : IContactService
    {
        private readonly IRepo<Contact> _repoContact;

        public ContactService(IRepo<Contact> repoContact)
        {
            _repoContact = repoContact;
        }

        public IQueryable<Contact> Contacts => _repoContact.Contacts;

        public Contact GetByKey(Guid? key)
        {
            var contact = _repoContact.GetById<Contact>(key);
            return contact;
        }
    }
}