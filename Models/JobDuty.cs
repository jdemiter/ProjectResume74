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

        public int WorkExperienceID { get; set; }
        [ForeignKey("WorkExperienceId")]
        public WorkExperience Job { get; set; }
    }
}
