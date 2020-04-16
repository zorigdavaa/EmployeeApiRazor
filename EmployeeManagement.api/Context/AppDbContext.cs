using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Department Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "PayRoll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            //Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(
             new Employee
                 {
                     EmployeeId = 1,
                     FirstName = "John",
                     LastName = "Hastings",
                     Emial = "David@pragimtech.com",
                     DateOfBirth = new DateTime(1980, 08, 05),
                     Gender = Gender.Female,
                     DepartmentId = 1,
                     PhotoPath = "images/john.png"
                 },
             new Employee
             {
                 EmployeeId = 2,
                 FirstName = "Sam",
                 LastName = "Galloway",
                 Emial = "Sam@pragimtech.com",
                 DateOfBirth = new DateTime(1981, 05, 01),
                 Gender = Gender.Male,
                 DepartmentId = 2,
                 PhotoPath = "images/Sam.png"
             },
            new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Emial = "Mary@pragimtech.com",
                DateOfBirth = new DateTime(1979, 01, 29),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/mary.png"
            },
             new Employee
             {
                 EmployeeId = 4,
                 FirstName = "Sara",
                 LastName = "Longway",
                 Emial = "sara@pragimtech.com",
                 DateOfBirth = new DateTime(1982, 09, 23),
                 Gender = Gender.Female,
                 DepartmentId = 3,
                 PhotoPath = "images/sara.png"
             });

        }
    }
}


