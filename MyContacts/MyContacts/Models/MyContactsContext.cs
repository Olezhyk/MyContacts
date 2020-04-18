using System.Data.Entity;

namespace MyContacts.Models
{
    public partial class MyContactsContext : DbContext
    {
        public MyContactsContext()
            : base("name=MyContactsContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Address_1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Address_2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Company_name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Web_site)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Full_name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.First_name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Home)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Web_site)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.User_name)
                .IsUnicode(false);
        }
    }
}
