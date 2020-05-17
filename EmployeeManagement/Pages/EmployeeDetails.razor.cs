using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Pages
{
    public class EmployeeDetailsBase:ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        protected string Coordinates { get; set; }
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;


        [Inject]
        public IEmployeeService EmployeeService { get; set; }


        public Employee Employee { get; set; } = new Employee();
        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(id));
            await base.OnInitializedAsync();
        }
        //protected void Mouse_Move(MouseEventArgs e)
        //{
        //    Coordinates = $"X={e.ClientX} Y={e.ClientY}";
        //}
        protected void Button_Click()
        {
            if (ButtonText=="Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "Hider";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }
    }
}
