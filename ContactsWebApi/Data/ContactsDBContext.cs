using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using ContactsWebApi.Models;

namespace ContactsWebApi.Data
{
    public class ContactsDBContext :DbContext
    {
        public ContactsDBContext() : base("ContactsDB")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactsDBContext, Migrations.Configuration>());
        }

        public DbSet<Contact> Contacts { get; set; }



    }
}