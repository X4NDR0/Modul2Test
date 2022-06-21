using Modul2Test2.SqlFacade;

namespace Modul2Test.ViewModels
{
    public class IndexViewModel
    {
        public Employee Employee { get; set; }
        public Zadatak Task { get; set; }
        public List<Zadatak> Tasks { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
