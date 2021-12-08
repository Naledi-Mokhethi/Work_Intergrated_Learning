using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Work_Intergrated_Learning.Data
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = {"pdf"};

                bool result = extension.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult(GetErrorMessage());
                }

               
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return "Allowed Extension Is pdf";
        }
    }
}
