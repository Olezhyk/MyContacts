namespace MyContacts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public Guid User_key { get; set; }

        [Required]
        [StringLength(50)]
        public string User_name { get; set; }
    }
}
