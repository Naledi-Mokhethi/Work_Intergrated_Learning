using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Work_Intergrated_Learning.Data;

namespace Work_Intergrated_Learning.Models
{
    public class User
    {
        [Required, MinLength(2, ErrorMessage = "Enter 2 Or More Letters"), Display(Name = "Full Names")]
        public string UserName { get; set; }
        [Required, MinLength(2, ErrorMessage = "Enter 2 Or More Letters")]
        public string Surname { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone, Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Student/Staff Number")]
        //public string Number { get; set; }
        public int Number { get; set; }
        //public int Faculty { get; set; }
     //   public Faculty FacultyId { get; set; }

        //public int Department { get; set; }
        // public Department DepartmentId { get; set; }
        public string Department { get; set; }

        [Display(Name = "Year Of Study")]
        public int YearOfStudy { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        [DataType(DataType.Password), Required]
        [Compare(nameof(Password), ErrorMessage = "Passwors do not match"), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [FileExtension]
        public string CV { get; set; }
        [Display(Name = "Academic Record"), FileExtension]
        public string AcademicRecord { get; set; }
      //  public string ProofofRegistration { get; set; }

        [NotMapped]
        public IFormFile CvUpload { get; set; }

        //[NotMapped]
        //public IFormFile ProofOfRegistration { get; set; }

        [NotMapped]
        public IFormFile AcademicRecordUpload { get; set; }

        public User() { }

        public User(AppUser appUser)
        {
            UserName = appUser.UserName;
            Surname = appUser.Surname;
            Email = appUser.Email;
            PhoneNumber = appUser.PhoneNumber;
            Number = appUser.Number;
            Department = appUser.Department;
            YearOfStudy = appUser.YearOfStudy;
            CV = appUser.CV;
            AcademicRecord = appUser.AcademicRecord;
            Password = appUser.PasswordHash;

        }



    }
}
