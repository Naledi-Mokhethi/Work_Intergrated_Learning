using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Models
{
    public class User
    {
        [Required, MinLength(2, ErrorMessage = "Enter 2 Or More Letters")]
        public string UserName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Enter 2 Or More Letters")]
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        public int Number { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwors do not match")]
        public string ConfirmPassword { get; set; }

        public string CV { get; set; }
        public string AcademicRecord { get; set; }

        [NotMapped]
        public IFormFile CvUpload { get; set; }

        [NotMapped]
        public IFormFile AcademicRecordUpload { get; set; }

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
