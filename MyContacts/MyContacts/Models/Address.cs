namespace MyContacts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        [Key]
        public Guid Address_key { get; set; }

        [StringLength(100)]
        public string Address_1 { get; set; }

        [StringLength(100)]
        public string Address_2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(10)]
        public string Zip_code { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}
