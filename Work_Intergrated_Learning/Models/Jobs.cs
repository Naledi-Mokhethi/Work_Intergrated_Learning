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
        [Required]
        public String JobTitle { get; set; }
        [Required]
        public String JobDescription { get; set; }
        [Required]
        public String JobRoleNResponsibilities { get; set; }
        [Required]
        public String Department { get; set; }
        public int Sorting { get; set; }

    }
}
