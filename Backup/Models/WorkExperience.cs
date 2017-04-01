using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class WorkExperience
    {
        public int ID { get; set; }
        public string Employer { get; set; }
        public string Location { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date Required")]
        public DateTime EmploymentStartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EmploymentEndDate { get; set; }
    }
}
