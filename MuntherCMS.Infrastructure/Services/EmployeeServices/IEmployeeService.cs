using MuntherCMS.Core.Dtos;
using MuntherCMS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuntherCMS.Infrastructure.Services.EmployeeServices 
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> AllEmployee();
        Task<int> Delete(int Id);
        Task<UpdateEmployeeDto> Get(int Id);
        Task<int> Create(CreateEmployeeDto empdto);
        Task<int> Update(UpdateEmployeeDto empdto);
    }
} 
