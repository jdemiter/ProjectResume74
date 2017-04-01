using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number requireed!")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter a valid phone number.")]
        [DataType (DataType.PhoneNumber)]
        [Display (Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
}
