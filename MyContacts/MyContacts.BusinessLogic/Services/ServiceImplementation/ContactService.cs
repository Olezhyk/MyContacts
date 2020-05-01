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
        private readonly IRepository<Contact> _repoContact;

        public ContactService(IRepository<Contact> repoContact)
        {
            _repoContact = repoContact;
        }
        
        public IQueryable<Contact> Get()
        {
            return _repoContact.Get<Contact>();
        }

        public Contact GetByKey(Guid? key)
        {
            var contact = _repoContact.GetById<Contact>(key);
            return contact;
        }

        public void Save(Contact entity)
        {
            if (_repoContact.Get<Contact>().Any(c => c.Contact_key == entity.Contact_key))
            {
                _repoContact.Update(entity);
            }
            else
            {
                _repoContact.Insert(entity);
            }

            _repoContact.SaveChanges();
        }

        public void Update(Contact entity)
        {
            _repoContact.Update(entity);
            _repoContact.SaveChanges();
        }

        public void Delete(Contact entity)
        {
            _repoContact.Delete(entity);

            _repoContact.SaveChanges();
        }
    }
}