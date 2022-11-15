using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuntherCMS.Core.Dtos;
using MuntherCMS.Core.ViewModels;
using MuntherCMS.Data.Models;


namespace MuntherCMS.Infrastructure.Services.EmployeeServices
{  
    public class EmployeeService : IEmployeeService
    {
        private readonly CMSDbContext _db ;

        private readonly IMapper _mapper ; 

        public EmployeeService (CMSDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> AllEmployee()
        {
            var employees = await _db.Employees.Where(x => !x.IsDelete).ToListAsync();

            var ListMap = _mapper.Map<List<EmployeeViewModel>>(employees);

            return ListMap;
        }
        public async Task<int> Delete(int Id)
        {
            var employee = await _db.Employees.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (employee == null)
            {
               // throw new EntityNotFoundException();
            }

            employee.IsDelete = true;
            var del = _db.Employees.Update(employee);

            await _db.SaveChangesAsync();
            return employee.Id;
        }
        public async Task<UpdateEmployeeDto> Get(int Id)
        {
            var emp = await _db.Employees.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (emp == null)
            {
                // throw new EntityNotFoundException();
            }
            var dtos = _mapper.Map<UpdateEmployeeDto>(emp);

            return dtos;
        }
        public async Task<int> Create(CreateEmployeeDto empdto)
        {
            var emplyee = _mapper.Map<Employee>(empdto);
            await _db.Employees.AddAsync(emplyee);
            await _db.SaveChangesAsync();
           
            return emplyee.Id;
        }
        public async Task<int> Update(UpdateEmployeeDto empdto)
        {
            var emp = await _db.Employees.SingleOrDefaultAsync(x => x.Id == empdto.Id && !x.IsDelete);
            if (emp == null)
            {
                // throw new EntityNotFoundException();
            }
            var map = _mapper.Map(empdto, emp);

            _db.Employees.Update(map);

            await _db.SaveChangesAsync();

            return emp.Id;
        }
    }
}
