using System;

namespace MyContacts.BusinessLogic.ViewModels
{
    public class ContactViewModel
    {
        public Guid ContactKey { get; set; }
        
        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName{ get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string WebSite { get; set; }

        public string Fax { get; set; }

        public string Home { get; set; }

        public Guid? CompanyKey { get; set; }

        public Guid? AddressKey { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }
    }
}