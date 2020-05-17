using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IDepartmentService
    {

        public Task<Department> GetDepartment(int id);
        public Task<IEnumerable<Department>> GetDepartments();

    }
}
