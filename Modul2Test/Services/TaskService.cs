using Modul2Test.Services.Interfaces;
using Modul2Test.ViewModels;
using Modul2Test2.SqlFacade;

namespace Modul2Test.Services
{
    public class TaskService : ITaskService
    {
        private ISqlFacade _ISqlFacade;
        public TaskService(ISqlFacade ISqlFacade)
        {
            _ISqlFacade = ISqlFacade;
        }

        public void AddTask(Zadatak task)
        {
            _ISqlFacade.AddTask(task);
        }

        public List<Zadatak> GetAllTasks()
        {
            List<Zadatak> tasks = _ISqlFacade.GetAllTasks();
            return tasks;
        }

        public void RemoveTask(int taskId)
        {
            _ISqlFacade.RemoveTask(taskId);
        }

        public void EditTask(Zadatak task)
        {
            _ISqlFacade.EditTask(task);
        }

        public Zadatak GetTask(int taskId)
        {
            List<Zadatak> tasks = _ISqlFacade.GetAllTasks();
            Zadatak task = tasks.FirstOrDefault(x => x.ID == taskId);
            return task;
        }

        public IndexViewModel CreatingIndexViewModel()
        {
            List<Employee> employees = _ISqlFacade.GetAllEmployees();
            List<Zadatak> tasks = _ISqlFacade.GetAllTasks();
            IndexViewModel model = new IndexViewModel { Employees = employees, Tasks = tasks };
            return model;
        }
    }
}
