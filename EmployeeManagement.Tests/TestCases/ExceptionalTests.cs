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
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IEmployeeService _employeeService;
        public readonly Mock<IEmployeeRepository> employeeservice = new Mock<IEmployeeRepository>();
        private readonly Employee _employee;
        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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
        public async Task<bool> GetEmployees_ReturnsEmptyList_WhenNoEmployees()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var employees = new List<Employee>();

            //Action
            try
            {
                employeeservice.Setup(repos => repos.GetEmployees()).Returns(employees);
                var result = _employeeService.GetEmployees();
                //Assertion
                if (result.Count()==0)
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
        public async Task<bool> GetEmployees_Returns_NullWhenRepositoryReturnsNull()
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
                if (result ==null)
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
