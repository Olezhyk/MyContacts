namespace MyContacts.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contacts", "Address_key");
            AddForeignKey("dbo.Contacts", "Address_key", "dbo.Addresses", "Address_key");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Address_key", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "Address_key" });
        }
    }
}
