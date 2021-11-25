using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Number { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }
        public string Password { get; set; }
        public string CV { get; set; }
        public string AcademicRecord { get; set; }

        public User() { }

        public User(AppUser appUser)
        {
            UserName = appUser.UserName;
            Email = appUser.Email;
            PhoneNumber = appUser.PhoneNumber;
            Password = appUser.PasswordHash;

        }



    }
}
