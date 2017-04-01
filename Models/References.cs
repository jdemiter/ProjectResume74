using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class References
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

    }
}
