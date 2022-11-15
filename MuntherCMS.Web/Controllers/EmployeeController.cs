using Microsoft.AspNetCore.Mvc;
using MuntherCMS.Core.Dtos;
using MuntherCMS.Infrastructure.Services.EmployeeServices;

namespace MuntherCMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
       
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View(_employeeService.AllEmployee());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                 _employeeService.Create(dto);
            }
            return View(dto);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var user =  _employeeService.Get(id);
            return View(user);
        }
        [HttpPost]
        public  IActionResult Update(UpdateEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                 _employeeService.Update(dto);
            }
            return View(dto);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        { 
            _employeeService.Delete(id);
             
            return Redirect("/Index");
        }
    }
}
