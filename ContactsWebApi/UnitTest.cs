
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactsWebApi.Models;
using ContactsWebApi.Controllers;

namespace ContactsWebApi.Test
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            var testContacts = GetTestContacts();
            var controller = new ContactsController();

            //var result = controller.Get() as List<Contact>;
            //Assert.AreEqual(testProducts.Count, result.Count);
        }

        private List<Contact> GetTestContacts()
        {
            var testContacts = new List<Contact>() {
            new Contact()
            {
                Id = 1,
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
                                    Id = 2,
                                    FirstName = "Katlian",
                                    LastName = "Seick",
                                    Dob = DateTime.Parse(DateTime.Today.ToString()),
                                    Email = "Seick.K@Solstice.com",
                                    Image = "",
                                    PersonalPhone = "213-123-1233",
                                    WorkPhone = "213-231-2332",
                                    Company = "Solstice",
                                    StreetAddress = "16st E Main St",
                                    City = "New York",
                                    State = "New York",
                                    ZipCode = "85001"
                                },
                                new Contact()
                                {
                                    Id = 3,
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
            };
            return testContacts;
        }
    }
}
