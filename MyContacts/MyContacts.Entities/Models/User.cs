using System;
using System.ComponentModel.DataAnnotations;

namespace MyContacts.Entities.Models
{
    public partial class User
    {
        [Key]
        public Guid User_key { get; set; }

        [Required]
        [StringLength(50)]
        public string User_name { get; set; }
    }
}
