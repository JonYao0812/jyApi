using jyApi.Contexts;
using jyApi.Models;
using System;
using System.Collections.Generic;

namespace jyApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public void CreateEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
        }

        public void DeleteEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Jonny", LastName = "Boy", Location = 2 },
                new Employee { Id = 2, FirstName = "Sunny", LastName = "Colucci", Location = 3 },
                new Employee { Id = 3, FirstName = "Hey", LastName = "You", Location = 2 }
            };


            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return new Employee { Id = 1, FirstName = "Jonny", LastName = "Boy", Location = 2 };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
