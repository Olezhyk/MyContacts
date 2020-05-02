using System;
using System.ComponentModel.DataAnnotations;

namespace MyContacts.Entities.Models
{
    public partial class Contact
    {
        [Key]
        public Guid Contact_key { get; set; }

        public Guid User_key { get; set; }
        
        public Guid? Company_key { get; set; }

        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string Full_name { get; set; }

        [StringLength(50)]
        [Display(Name = "First Name")]
        public string First_name { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string Last_name { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public Guid? Address_key { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

        [StringLength(25)]
        public string Mobile { get; set; }

        [StringLength(25)]
        public string Home { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Web Site")]
        public string Web_site { get; set; }
        
        public virtual Company Company { get; set; }
    }
}
