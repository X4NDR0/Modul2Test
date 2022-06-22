using Modul2Test2.SqlFacade;
using NUnit.Framework;

namespace Modul2TestUnitTest
{
    public class Tests
    {
        private SqlFacade _sqlFacade;

        public Tests()
        {
            _sqlFacade = new SqlFacade();
        }

        [Test]
        public void RemovingTask()
        {
            //Arrange
            Employee employee = new Employee { NameAndSurname = "Unit Test", Workplace = "UnitTest" };

            //Act
            int employeeId = _sqlFacade.AddEmployee(employee);
            Zadatak expectedResult = new Zadatak { WorkerID = employeeId, Title = "UnitTest", EstimatedTime = 8, Difficulty = 5, Description = "UnitTest", Status = "zavrsen" };

            int taskId = _sqlFacade.AddTask(expectedResult);
            _sqlFacade.RemoveTask(taskId);

            //Assert
            Assert.IsNotNull(expectedResult);
        }

        [Test]
        public void AddingTask()
        {
            //Arrange
            Employee employee = new Employee { NameAndSurname = "Unit Test", Workplace = "UnitTest" };

            //Act
            int employeeId = _sqlFacade.AddEmployee(employee);
            Zadatak expectedResult = new Zadatak { WorkerID = employeeId, Title = "UnitTest", EstimatedTime = 8, Difficulty = 5, Description = "UnitTest", Status = "zavrsen" };
            int taskId = _sqlFacade.AddTask(expectedResult);
            Zadatak result = _sqlFacade.GetTaskByID(taskId);

            //Assert
            Assert.AreEqual(expectedResult.Title, result.Title);
        }

        [Test]
        public void EditTask()
        {
            //Arrange
            Employee employee = new Employee { NameAndSurname = "Unit Test", Workplace = "UnitTest" };

            //Act
            int employeeId = _sqlFacade.AddEmployee(employee);
            Zadatak expectedResult = new Zadatak { WorkerID = employeeId, Title = "UnitTest", EstimatedTime = 8, Difficulty = 5, Description = "UnitTest", Status = "zavrsen" };
            int taskId = _sqlFacade.AddTask(expectedResult);
            expectedResult.Title = "EditedUnitTest";
            _sqlFacade.EditTask(expectedResult);
            Zadatak result = _sqlFacade.GetTaskByID(taskId);

            //Assert
            Assert.AreNotEqual(expectedResult.Title, result.Title);
        }
    }
}