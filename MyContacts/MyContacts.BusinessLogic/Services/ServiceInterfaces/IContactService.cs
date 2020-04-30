using System;
using System.Linq;
using System.Threading.Tasks;
using MyContacts.Entities.Models;

namespace MyContacts.BusinessLogic.Services.ServiceInterfaces
{
    public interface IContactService
    {
        IQueryable<Contact> Contacts { get; }
        Contact GetByKey(Guid? key);
    }
}