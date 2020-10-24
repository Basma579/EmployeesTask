using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesTask.Models;

namespace EmployeesAPI.Models
{
    public class AppDBContext : DbContext
    {

         public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Employees> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employees>().HasData(new Employees
            {
                EmployeeID = 1,
                EmployeeName = "John" ,
                EmployeeSalary = 2500 
             
            });


            modelBuilder.Entity<Employees>().HasData(new Employees
            {
                EmployeeID = 2,
                EmployeeName = "Maria",
                EmployeeSalary = 4000

            });

            modelBuilder.Entity<Employees>().HasData(new Employees
            {
                EmployeeID = 3,
                EmployeeName = "Sara",
                EmployeeSalary = 5000

            });
        }
    }
}
