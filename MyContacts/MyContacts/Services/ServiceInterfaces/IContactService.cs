using System;
using System.Threading.Tasks;
using MyContacts.Entities.Models;

namespace MyContacts.Services.ServiceInterfaces
{
    public interface IContactService
    {
        Task<Contact> GetByKey(Guid? key);
    }
}