//namespace MyContacts
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    public partial class Contact
//    {
//        [Key]
//        public Guid Contact_key { get; set; }

//        public Guid User_key { get; set; }

//        public Guid? Created_by { get; set; }

//        public DateTime? Mreated_date { get; set; }

//        public Guid? Modified_by { get; set; }

//        public DateTime? Modified_date { get; set; }

//        public Guid? Company_key { get; set; }

//        [StringLength(100)]
//        public string Full_name { get; set; }

//        [StringLength(50)]
//        public string First_name { get; set; }

//        [StringLength(50)]
//        public string Last_name { get; set; }

//        [StringLength(100)]
//        public string Title { get; set; }

//        public Guid? Address_key { get; set; }

//        [StringLength(25)]
//        public string Phone { get; set; }

//        [StringLength(25)]
//        public string Fax { get; set; }

//        [StringLength(25)]
//        public string Mobile { get; set; }

//        [StringLength(25)]
//        public string Home { get; set; }

//        [StringLength(100)]
//        public string Email { get; set; }

//        [StringLength(100)]
//        public string Web_site { get; set; }
//    }
//}
