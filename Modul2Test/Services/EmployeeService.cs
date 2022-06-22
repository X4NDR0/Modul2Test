using Modul2Test.Services.Interfaces;
using Modul2Test2.SqlFacade;

namespace Modul2Test.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ISqlFacade _ISqlFacade;

        public EmployeeService(ISqlFacade ISqlFacade)
        {
            _ISqlFacade = ISqlFacade;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _ISqlFacade.GetAllEmployees();
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            _ISqlFacade.AddEmployee(employee);
        }
    }
}
