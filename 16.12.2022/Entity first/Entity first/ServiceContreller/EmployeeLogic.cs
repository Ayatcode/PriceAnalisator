using Entity_first.Core.Classes;
using Entity_first.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_first.ServiceContreller
{
    public class EmployeeServiceLogic
    {


        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            AppDbContext context = new();

            var Result = context.employees;

            Result.ToList();
            foreach (var em in Result)
            {
                employees.Add(em);
            }
            return employees;
        }

        public Employee GetAllEmployeesByID(int Id)
        {


            AppDbContext context = new();

            var Result = context.employees.Where(e => e.Id == Id).ToList();


            Employee employee = new Employee()
            {
                Id = Result.FirstOrDefault().Id,
                Name = Result.FirstOrDefault().Name,
                Surname = Result.FirstOrDefault().Surname,
                Salary = Result.FirstOrDefault().Salary

            };


            return employee;
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {

            AppDbContext context = new();


            await context.AddAsync(employee);
            await context.SaveChangesAsync();



        }
        public Employee GetAllEmployeesByName(String Name)
        {


            AppDbContext context = new();

            var Result = context.employees.Where(e => e.Name == Name).ToList();


            Employee employee = new Employee()
            {
                Id = Result.FirstOrDefault().Id,
                Name = Result.FirstOrDefault().Name,
                Surname = Result.FirstOrDefault().Surname,
                Salary = Result.FirstOrDefault().Salary

            };
            return employee;

        }
    }
}
}
