using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
        public string Surname { get; set; }
        //public string Number { get; set; }
        public int Number { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }
        public string CV { get; set; }
        public string AcademicRecord { get; set; }

    }
}
