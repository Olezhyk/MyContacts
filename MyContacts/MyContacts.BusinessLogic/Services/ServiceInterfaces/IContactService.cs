using System;
using System.Linq;
using System.Threading.Tasks;
using MyContacts.Entities.Models;

namespace MyContacts.BusinessLogic.Services.ServiceInterfaces
{
    public interface IContactService
    {
        IQueryable<Contact> Get();

        Contact GetByKey(Guid? key);

        void Save(Contact entity);

        void Update(Contact entity);

        void Delete(Contact entity);
    }
}