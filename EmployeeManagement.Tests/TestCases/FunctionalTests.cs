using EmployeeManagement.BusinessLayer.Services;
using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.BusinessLayer.Interfaces;
using EmployeeManagement.BusinessLayer.Services.Repository;
using Xunit;
using Xunit.Abstractions;
using Moq;

namespace EmployeeManagement.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IEmployeeService _employeeService;
        public readonly Mock<IEmployeeRepository> employeeservice = new Mock<IEmployeeRepository>();
        private readonly Employee _employee;
        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
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
        public async Task<bool> GetEmployees_ReturnsListOfEmployees()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, EmployeeName = "John Doe", Salary = 50000 },
                new Employee { EmployeeID = 2, EmployeeName = "Jane Smith", Salary = 60000 },
            };

            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (employees.Count == result.Count())
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
        public async Task<bool> GetEmployees_ReturnsEmployeeCount()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, EmployeeName = "John Doe", Salary = 50000 },
                new Employee { EmployeeID = 2, EmployeeName = "Jane Smith", Salary = 60000 },
            };

            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (employees.Count == result.Count())
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
        public async Task<bool> GetEmployees_ReturnsFirst100Employees_WhenRepositoryReturnsMoreThan100Employees()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>();
            for (int i = 1; i <= 150; i++)
            {
                employees.Add(new Employee { EmployeeID = i, EmployeeName = $"Employee {i}", Salary = 50000 });
            }

            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (result.Count() == 150)
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
        public async Task<bool> GetEmployees_ReturnsEmptyList_WhenRepositoryReturnsNegativeSalary()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, EmployeeName = "John Doe", Salary = -50000 },
                new Employee { EmployeeID = 2, EmployeeName = "Jane Smith", Salary = -60000 },
                new Employee { EmployeeID = 3, EmployeeName = "Alice Johnson", Salary = -70000 }
            };
            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (result.Any(x=>x.Salary<0))
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


