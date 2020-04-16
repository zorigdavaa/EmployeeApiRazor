using EmployeeManagement.api.Context;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result= await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Employee> DeleteEmployee(int employeeID)
        {
            var employee= _context.Employees.Find(employeeID);
            if (employee!=null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            return null;

        }

        public async Task<Employee> GetEmployee(int employeeid)
        {
            return await _context.Employees.FindAsync(employeeid);
            
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Emial == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _context.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if (gender!=null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var Employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            if (Employee!=null)
            {
                Employee.FirstName = employee.FirstName;
                Employee.LastName = employee.LastName;
                Employee.Emial = employee.Emial;
                Employee.DateOfBirth = employee.DateOfBirth;
                Employee.Gender = employee.Gender;
                Employee.DepartmentId = employee.DepartmentId;
                Employee.PhotoPath = employee.PhotoPath;
                await _context.SaveChangesAsync();
                return Employee;
            }
            return null;
        }
    }
}
