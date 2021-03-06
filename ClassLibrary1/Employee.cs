﻿using EmployeeManagement.Models.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Employee
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
        public string Emial { get; set; }
        [Required]
        [DataType(DataType.Date)]
          public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        //navigation property
        public Department Department { get; set; }
    }
}
