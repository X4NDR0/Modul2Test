using Microsoft.AspNetCore.Mvc;
using Modul2Test.Services.Interfaces;
using Modul2Test.ViewModels;
using Modul2Test2.SqlFacade;

namespace Modul2Test.Controllers
{
    public class TaskController : Controller
    {
        private IEmployeeService _IEmployeeService;
        private ITaskService _ITaskService;

        public TaskController(IEmployeeService IEmployeeService, ITaskService ITaskService)
        {
            _IEmployeeService = IEmployeeService;
            _ITaskService = ITaskService;
        }

        public IActionResult Index()
        {
            IndexViewModel model = _ITaskService.CreatingIndexViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Zadatak task)
        {
            if (!ModelState.IsValid)
            {
                IndexViewModel model = _ITaskService.CreatingIndexViewModel();
                return View(model);
            }
            _ITaskService.AddTask(task);
            return RedirectToAction("Index", "Task");
        }

        public IActionResult RemoveTask(int taskId)
        {
            _ITaskService.RemoveTask(taskId);
            return RedirectToAction("Index", "Task");
        }

        public IActionResult EditTask(int taskId)
        {
            Zadatak task = _ITaskService.GetTask(taskId);
            return View(task);
        }

        [HttpPost]
        public IActionResult EditTask(Zadatak task)
        {
            _ITaskService.EditTask(task);
            return RedirectToAction("Index", "Task");
        }
    }
}
