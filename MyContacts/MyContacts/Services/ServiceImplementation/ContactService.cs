using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyContacts.DataAccess;
using MyContacts.DataAccess.Implementation;
using MyContacts.Entities.Models;
using MyContacts.Services.ServiceInterfaces;

namespace MyContacts.Services.ServiceImplementation
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IRepo<Contact> _repoContact;
        public ContactService(ILogger logger, IRepo<Contact> repoContact) : base(logger)
        {
            _repoContact = repoContact;
        }
        public async Task<Contact> GetByKey(Guid? key)
        {
            var contact = await _repoContact.GetByIdAsync<Contact>(key);
            return contact;
        }
    }
}