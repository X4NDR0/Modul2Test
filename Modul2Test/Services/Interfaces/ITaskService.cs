using Modul2Test.ViewModels;
using Modul2Test2.SqlFacade;

namespace Modul2Test.Services.Interfaces
{
    public interface ITaskService
    {
        public void AddTask(Zadatak task);
        public List<Zadatak> GetAllTasks();
        public void RemoveTask(int taskId);
        public void EditTask(Zadatak task);
        public EditTaskViewModel GetTask(int taskId);
        public IndexViewModel CreatingIndexViewModel();
    }
}
