using EmployeeManagement.BusinessLayer.Interfaces;
using EmployeeManagement.BusinessLayer.Services.Repository;
using EmployeeManagement.BusinessLayer.Services;
using EmployeeManagement.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;

namespace EmployeeManagement.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IEmployeeService _employeeService;
        public readonly Mock<IEmployeeRepository> employeeservice = new Mock<IEmployeeRepository>();
        private readonly Employee _employee;
        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _employeeService = new EmployeeService(employeeservice.Object);
            _output = output;
            _employee = new Employee()
            {
                EmployeeID = 1,
                EmployeeName = "Anna",
                Salary = 34000
            };
        }

        [Fact]
        public async Task<bool> GetEmployees_ReturnsNull_WhenRepositoryReturnsNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
      
            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns((List<Employee>)null);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (result==null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> GetEmployees_ReturnsListOfEmployees_WhenMultipleEmployees()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, EmployeeName = "John Doe", Salary = 50000 },
                new Employee { EmployeeID = 2, EmployeeName = "Jane Smith", Salary = 60000 },
                new Employee { EmployeeID = 3, EmployeeName = "Alice Johnson", Salary = 70000 },
            };

            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (result.Count() == employees.Count)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> GetEmployees_ReturnsSingleEmployee_WhenOnlyOneEmployee()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, EmployeeName = "John Doe", Salary = 50000 },
            };

            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (result.Count() == 1)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> GetEmployees_CountShouldNotBeZero()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, EmployeeName = "John Doe", Salary = 50000 },
            };

            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (result.Count()!=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}
