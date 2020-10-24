using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesTask.Models;

namespace EmployeesAPI.Models
{
   public interface IEmployeeRepository
    {
            Task<IEnumerable<Employees>> GetEmployees();
            Task<Employees> GetEmployee(int employeeId);
            Task<Employees> AddEmployee(Employees employee);
            Task<Employees> UpdateEmployee(Employees employee);
            Task<Employees> DeleteEmployee(int employeeId);
    }
}
