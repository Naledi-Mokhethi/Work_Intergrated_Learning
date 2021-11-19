using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        [Required, MinLength(4, ErrorMessage ="Enter a minimum of 4 characters")]
        public String FacultyName { get; set; }
        public String Slug { get; set; }
        public int Sorting { get; set; }
    }
}
