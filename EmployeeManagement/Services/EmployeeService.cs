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
        //Test implementation
        public async Task<IEnumerable<Employee>> GetAsync(string url)
        {
            return await httpClient.GetJsonAsync<Employee[]>(url);
        }        //TODO
        //CODE FOR POST, PUT, DELETE CAN BE ADDED

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }




        //This is real one
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //Microsoft.AspNetCore.Components; name spacees irsen shuud serialize hiideg yum bna;
            return await httpClient.GetJsonAsync<Employee[]>("api/employees");
        }
    }
}
