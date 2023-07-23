using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BusinessLayer.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
    }
}
