namespace ContactsWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Company = c.String(maxLength: 100),
                        Image = c.String(),
                        Email = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        WorkPhone = c.String(),
                        PersonalPhone = c.String(nullable: false),
                        StreetAddress = c.String(maxLength: 100),
                        City = c.String(maxLength: 28),
                        State = c.String(maxLength: 20),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
