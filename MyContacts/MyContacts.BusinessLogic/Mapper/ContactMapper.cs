using System.Collections.Generic;
using System.Threading.Tasks;
using MyContacts.BusinessLogic.Mapper.MapperInterfaces;
using MyContacts.BusinessLogic.ViewModels;
using MyContacts.Entities.Models;

namespace MyContacts.BusinessLogic.Mapper
{
    public class ContactMapper : IContactMapper
    {
        public ContactViewModel MapContactToContactViewModel(Contact entity)
        {
            ContactViewModel model = null;
            if (entity != null)
            {
                model = new ContactViewModel
                {
                    ContactKey = entity.Contact_key,
                    Email = entity.Email,
                    Mobile = entity.Mobile,
                    Phone = entity.Phone,
                    FullName = entity.Full_name,
                    FirstName = entity.First_name,
                    Title = entity.Title,
                    WebSite = entity.Web_site,
                    Fax = entity.Fax,
                    CompanyName = entity.Company?.Company_name
                };

            }

            return model;
        }
    }
}