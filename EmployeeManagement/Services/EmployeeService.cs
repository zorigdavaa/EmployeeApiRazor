using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //Microsoft.AspNetCore.Components; name spacees irsen shuud serialize hiideg yum bna;
            return await httpClient.GetJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await httpClient.PutJsonAsync<Employee>($"api/employees/{employee.EmployeeId}",employee);
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await httpClient.PostJsonAsync<Employee>($"api/employees", employee);
        }
    }
}
