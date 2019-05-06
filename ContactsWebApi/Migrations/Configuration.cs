namespace ContactsWebApi.Migrations
{
    using ContactsWebApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactsWebApi.Data.ContactsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactsWebApi.Data.ContactsDBContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
                context.Contacts.AddOrUpdate(x => x.Id,
                                new Contact()
                                { 
                                    Id =1,
                                    FirstName = "George",
                                    LastName = "Peters",
                                    Dob = DateTime.Parse(DateTime.Today.ToString()),
                                    Email = "g.peter123@gmail.com",
                                    Image = "",
                                    PersonalPhone = "213.123.3123",
                                    WorkPhone = "213-233-1232",
                                    Company = "ABCCorp",
                                    StreetAddress = "22nd E Elgin St",
                                    City = "Logan",
                                    State = "Utah",
                                    ZipCode = "57684"
                                },
                                new Contact()
                                {
                                    Id =2,
                                    FirstName = "Katlian",
                                    LastName = "Seick",
                                    Dob = DateTime.Parse(DateTime.Today.ToString()),
                                    Email = "Seick.K@Solstice.com",
                                    Image = "",
                                    PersonalPhone = "213-123-1233",
                                    WorkPhone = "213-231-2332",
                                    Company = "Solstice",
                                    StreetAddress = "16st E Main St",
                                    City =  "New York",
                                    State = "New York",
                                    ZipCode = "85001"
                                },
                                new Contact()
                                {
                                    Id=3,
                                    FirstName = "Mohan",
                                    LastName = "Renu",
                                    Dob = DateTime.Parse(DateTime.Today.ToString()),
                                    Email = "kumarin_phx@gmail.com",
                                    Image = "",
                                    PersonalPhone = "480.489.8806",
                                    WorkPhone = "(1)480-352-2158",
                                    Company = "Idealforce",
                                    StreetAddress = "1st E Elgin St",
                                    City = "Tempe",
                                    State = "Arizona",
                                    ZipCode = "85283"
                                }
                    );
           
         
        }
    }
}
