namespace Modul2Test2.SqlFacade
{
    public interface ISqlFacade
    {
        public int AddTask(Zadatak task);
        public List<Employee> GetAllEmployees();
        public List<Zadatak> GetAllTasks();
        public void RemoveTask(int taskId);
        public void EditTask(Zadatak task);
        public int AddEmployee(Employee employee);
        public Zadatak GetTaskByID(int taskId);
    }
}
