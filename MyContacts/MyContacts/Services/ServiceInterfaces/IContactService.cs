using System;

namespace MyContacts.Services.ServiceInterfaces
{
    public interface IContactService
    {
        Contact GetByKey(Guid? key);
    }
}