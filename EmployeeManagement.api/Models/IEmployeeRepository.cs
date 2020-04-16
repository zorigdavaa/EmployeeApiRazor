﻿using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.api.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeid);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int employeeID);
    }
}
