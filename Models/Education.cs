using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectResume.Models
{
    public class Education
    {
        public int ID { get; set; }
        public string School { get; set; }
        [Display(Name = "Degree Received")]
        public string DegreeReceived { get; set; }
        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

    }
}
