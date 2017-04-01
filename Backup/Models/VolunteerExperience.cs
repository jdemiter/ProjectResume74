using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class VolunteerExperience
    {
        public int ID { get; set; }
        [Display(Name = "Volunteer Organization")]
        public string VolunteerOrganization { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime VolunteerStartDate { get; set; }
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime VolunteerEndDate { get; set; }
        [Display(Name = "Volunteer Duties")]
        public string VolunteerDuties { get; set; }

    }
}
