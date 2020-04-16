using EmployeeManagement.api.Context;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Department> GetDepartment(int departmentid)
        {
            return await _context.Departments.FindAsync(departmentid);
        }

        public async Task< IEnumerable<Department>> GetDepartments()
        {
           return await _context.Departments.ToListAsync();
        }
    }
}
