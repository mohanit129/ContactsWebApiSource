using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactsWebApi.Models
{
    public class Contact
    {
        public int Id { get; set; }

       [Required]
       // [Display(Name ="First Name")]
       // [StringLength(40,ErrorMessage = "Cannot be more than 40 Characters!")]
        public string FirstName { get; set; }

        [Required]
       // [Display(Name = "Last Name")]
       // [StringLength(60,ErrorMessage = "Cannot be more than 60 Characters!")]
        public string LastName { get; set; }

        [StringLength(100,ErrorMessage = "Exceeds 100 Characters!")]
        public string Company { get; set; }

        
        public string Image { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime Dob { get; set; }
        
       [Display(Name = "Work Phone")]
       [Phone(ErrorMessage = "Incorrect Phone Number Format!")]
        public string WorkPhone { get; set; }

        [Required]
        [Phone(ErrorMessage = "Incorrect Phone Number Format!")]  
        [Display(Name = "Personal Phone")]
        public string PersonalPhone { get; set; }

        [StringLength(100, ErrorMessage = "Cannot be more than 100 Characters!")]
        public string StreetAddress { get; set; }

        [StringLength(28, ErrorMessage = "Cannot be more than 28 Characters!")]
        public string City { get; set; }

       [StringLength(20, ErrorMessage = "Cannot be more than 20 Characters!")]
        public string State { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5)]
        //[RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }

    }
}