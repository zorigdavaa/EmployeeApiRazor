using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.CustomValidation
{
    public class DateRangeValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime minvalue = DateTime.Now.AddYears(-18);
        

            if ((DateTime)value > minvalue)
            {
                //return new ValidationResult("Age must be 18+", new[] { validationContext.MemberName });
                return new ValidationResult("Age must be 18+");
            }

            return null;
        }

    }
}
