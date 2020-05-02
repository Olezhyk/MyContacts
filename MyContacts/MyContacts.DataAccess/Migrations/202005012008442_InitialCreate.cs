namespace MyContacts.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Address_key = c.Guid(nullable: false),
                        Address_1 = c.String(maxLength: 100, unicode: false),
                        Address_2 = c.String(maxLength: 100, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        State = c.String(maxLength: 30, unicode: false),
                        Zip_code = c.String(maxLength: 10, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Address_key);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Company_key = c.Guid(nullable: false),
                        Company_name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Address_key = c.Guid(nullable: false),
                        Phone = c.String(maxLength: 25, unicode: false),
                        Fax = c.String(maxLength: 25, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Web_site = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Company_key);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Contact_key = c.Guid(nullable: false),
                        User_key = c.Guid(nullable: false),
                        Company_key = c.Guid(),
                        Full_name = c.String(maxLength: 100, unicode: false),
                        First_name = c.String(maxLength: 50, unicode: false),
                        Last_name = c.String(maxLength: 50, unicode: false),
                        Title = c.String(maxLength: 100, unicode: false),
                        Address_key = c.Guid(),
                        Phone = c.String(maxLength: 25, unicode: false),
                        Fax = c.String(maxLength: 25, unicode: false),
                        Mobile = c.String(maxLength: 25, unicode: false),
                        Home = c.String(maxLength: 25, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Web_site = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Contact_key)
                .ForeignKey("dbo.Companies", t => t.Company_key)
                .Index(t => t.Company_key);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_key = c.Guid(nullable: false),
                        User_name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.User_key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Company_key", "dbo.Companies");
            DropIndex("dbo.Contacts", new[] { "Company_key" });
            DropTable("dbo.Users");
            DropTable("dbo.Contacts");
            DropTable("dbo.Companies");
            DropTable("dbo.Addresses");
        }
    }
}
