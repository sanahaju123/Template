using EmployeeManagement.DataLayer;
using EmployeeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BusinessLayer.Services.Repository
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            //Write Your Code Here
            throw new NotImplementedException();
        }
    }
}
