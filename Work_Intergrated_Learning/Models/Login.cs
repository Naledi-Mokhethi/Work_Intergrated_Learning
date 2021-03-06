using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Models
{
    public class Login
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}
