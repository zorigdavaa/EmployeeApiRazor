using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest=>dest.ConfirmEmail,opt=>opt.MapFrom(x=>x.Emial));
            CreateMap<EditEmployeeModel,Employee>();
        }
    }
}
