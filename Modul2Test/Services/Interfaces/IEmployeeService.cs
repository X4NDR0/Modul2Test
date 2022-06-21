using Modul2Test2.SqlFacade;

namespace Modul2Test.Services.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public void AddEmployee(Employee employee);

    }
}
