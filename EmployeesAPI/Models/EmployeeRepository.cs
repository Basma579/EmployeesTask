using EmployeesTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext appDbContext ;
        public EmployeeRepository(AppDBContext appDBContext)
        {
            this.appDbContext = appDBContext;
        }
        public async Task<Employees> AddEmployee(Employees employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Employees> DeleteEmployee(int employeeId)
        {
            var result = appDbContext.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
               await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employees> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees
                   .FirstOrDefaultAsync(e => e.EmployeeID == employeeId);
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employees> UpdateEmployee(Employees employee)
        {
            var result = await appDbContext.Employees
               .FirstOrDefaultAsync(e => e.EmployeeID == employee.EmployeeID);

            if (result != null)
            {
                result.EmployeeName = employee.EmployeeName;
                result.EmployeeSalary = employee.EmployeeSalary;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
