using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject] public IEmployeeService EmployeeService { get; set; }
        [Inject] public IDepartmentService DepartmentService { get; set; }
        [Inject] public IMapper Mapper { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Parameter] public string Id { get; set; }
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        public List<Department> Departments { get; set; } = new List<Department>();

        protected async Task HandleValidSubmit() 
        {
            Mapper.Map(EditEmployeeModel, Employee);
            Employee result=null;
            if (Employee.EmployeeId!=0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
                if (result != null)
                {
                    NavigationManager.NavigateTo("/");
                }
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
                if (result!=null)
                {
                    NavigationManager.NavigateTo("/");
                }
            }

            

        }



        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if (employeeId != 0)
            {
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.png"
                };
            }
            Mapper.Map(Employee, EditEmployeeModel);
            Departments = (await DepartmentService.GetDepartments()).ToList();
        }
    }
}
