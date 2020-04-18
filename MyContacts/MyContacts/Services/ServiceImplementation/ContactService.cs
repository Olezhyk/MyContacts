using System;
using MyContacts.Services.ServiceInterfaces;

namespace MyContacts.Services.ServiceImplementation
{
    public class ContactService : IContactService
    {
        public Contact GetByKey(Guid? key)
        {
            throw new NotImplementedException();
        }
    }
}