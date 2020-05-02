using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyContacts.BusinessLogic.Mapper.MapperInterfaces;
using MyContacts.BusinessLogic.ViewModels;
using MyContacts.Entities.Models;
using MyContacts.VcfProvider.Models;

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

        public VcfData MapContactToVcf(Contact entity)
        {
            VcfData vcfData = null;

            if (entity != null)
            {
                vcfData = new VcfData
                {
                    FirstName = entity.First_name,
                    LastName = entity.Last_name,
                    Title = entity.Title,
                    CountryName = entity.Address.Country,
                    ZipCode = entity.Address.Zip_code,
                    Address1 = entity.Address.Address_1,
                    Address2 = entity.Address.Address_2,
                    City = entity.Address.City,
                    State = entity.Address.State,
                    WorkPhone = entity.Phone,
                    HomePhone = entity.Home,
                    Email = entity.Email,
                    Mobile = entity.Mobile,
                    FullName = entity.Full_name,
                    WebSite = entity.Web_site,
                    Fax = entity.Fax,
                    CompanyName = entity.Company?.Company_name
                };
            }

            return vcfData;
        }

        public Contact MapEditContactViewModelToEntity(ContactViewModel model, Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}