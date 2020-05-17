using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.CustomValidation;

namespace EmployeeManagement.Models
{
    public class EditEmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "pragimtech.com")]
        public string Emial { get; set; }
        [CompareProperty("Emial")]
        public string ConfirmEmail { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DateRangeValidation]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        //navigation property
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
    }
}
