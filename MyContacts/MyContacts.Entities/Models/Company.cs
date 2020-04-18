using System;
using System.ComponentModel.DataAnnotations;

namespace MyContacts.Entities.Models
{
    public partial class Company
    {
        [Key]
        public Guid Company_key { get; set; }

        [Required]
        [StringLength(100)]
        public string Company_name { get; set; }

        public Guid? Created_by { get; set; }

        public DateTime? Created_date { get; set; }

        public Guid? Modified_by { get; set; }

        public DateTime? Modified_date { get; set; }

        public Guid Address_key { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(25)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Web_site { get; set; }
    }
}
