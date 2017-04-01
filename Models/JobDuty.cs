using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResume.Models
{
    public class JobDuty
    {
        public int ID { get; set; }

        //JobDuty properties
        public string Responsibilities { get; set; }

        public int? WorkExperienceID { get; set; }
        
        
        public WorkExperience Employer { get; set; }

        public int? PersonID { get; set; }
        [ForeignKey("PersonID")]
        public Person person { get; set; }
    }
}
