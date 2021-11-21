using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage = "Enter a minimum of 4 characters")]
        public String DepName { get; set; }
        public int FacultyId { get; set; }
        public String Slug { get; set; }
        public int Sorting { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
    }
}
