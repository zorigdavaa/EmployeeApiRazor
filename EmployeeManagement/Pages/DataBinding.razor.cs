using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Pages
{
    public class DataBindingBase:ComponentBase
    {
        public string Name { get; set; } = "Tom";
        public string Colour { get; set; } = "background-color:black";
    }
}
