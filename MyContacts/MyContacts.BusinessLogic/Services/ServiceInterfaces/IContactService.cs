using System;
using System.Threading.Tasks;
using MyContacts.Entities.Models;

namespace MyContacts.BusinessLogic.Services.ServiceInterfaces
{
    public interface IContactService
    {
        Contact GetByKey(Guid? key);
    }
}