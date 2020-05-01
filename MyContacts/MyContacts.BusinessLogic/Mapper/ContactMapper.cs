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
                    //Greeting = entity.greeting,
                    //Title = entity.title,
                    //CountryName = entity.main_address_info?.country_key,
                    //ZipCode = entity.main_address_info?.zip_code,
                    //Address1 = entity.main_address_info?.address_1,
                    //Address2 = entity.main_address_info?.address_2,
                    //City = entity.main_address_info?.city,
                    //State = entity.main_address_info?.state,
                    //WorkPhone = entity.work,
                    //HomePhone = entity.home,
                    //Email = entity.email,
                    //Mobile = entity.mobile,
                    //FullName = entity.full_name,
                    //WebSite = entity.web_site,
                    //Fax = entity.fax,
                    //CompanyName = entity.company_info != null
                    //    ? entity.company_info.address_info != null &&
                    //      entity.company_info.address_info.company != null
                    //        ? entity.company_info.address_info.company
                    //        : entity.company_info.organization_id
                    //    : entity.main_address_info != null
                    //        ? entity.main_address_info.company
                    //        : null
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