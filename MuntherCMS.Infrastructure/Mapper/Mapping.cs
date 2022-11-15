using AutoMapper;
using MuntherCMS.Core.Dtos;
using MuntherCMS.Core.ViewModels;
using MuntherCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuntherCMS.Infrastructure.Mapper
{
    public class Mapping :Profile
    {
        public Mapping()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
