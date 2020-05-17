using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Pages
{
    public class EmployeeListBase:ComponentBase
    {
        public EmployeeListBase()
        {

        }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public bool showFooter { get; set; } = true;
        public int EmployeeCount { get; set; }

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                EmployeeCount++;
            }
            else
            {
                EmployeeCount--;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
            
        }
               
    }
}
