using Microsoft.AspNetCore.Mvc;
using Modul2Test.Services.Interfaces;
using Modul2Test.ViewModels;
using Modul2Test2.SqlFacade;

namespace Modul2Test.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _IEmployeeService;
        private ITaskService _ITaskService;
        public EmployeeController(IEmployeeService IEmployeeService, ITaskService ITaskService)
        {
            _IEmployeeService = IEmployeeService;
            _ITaskService = ITaskService;
        }

        public IActionResult DisplayAllEmployees()
        {
            List<Employee> employees = _IEmployeeService.GetAllEmployees();
            List<Zadatak> tasks = _ITaskService.GetAllTasks();
            DisplayAllEmployeesViewModel model = new DisplayAllEmployeesViewModel { Employees = employees, Tasks = tasks };
            return View(model);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _IEmployeeService.AddEmployee(employee);
            return RedirectToAction("DisplayAllEmployees", "Employee");
        }
    }
}
