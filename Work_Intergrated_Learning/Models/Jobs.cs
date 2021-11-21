using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public String Slug { get; set; }
        [Display(Name = "Job Title")]
        [Required]
        public String JobTitle { get; set; }
        [Required]
        [Display(Name = "Job Description")]
        public String JobDescription { get; set; }
        [Required]
        [Display(Name = "Roles and Responsibilities")]
        public String JobRoleNResponsibilities { get; set; }
        //[Required]
        public String Department { get; set; }
        public int Sorting { get; set; }

    }
}
