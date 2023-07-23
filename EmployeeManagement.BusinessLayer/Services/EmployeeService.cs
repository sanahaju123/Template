using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.BusinessLayer.Interfaces;
using EmployeeManagement.BusinessLayer.Services.Repository;
using EmployeeManagement.Entities;

namespace EmployeeManagement.BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
