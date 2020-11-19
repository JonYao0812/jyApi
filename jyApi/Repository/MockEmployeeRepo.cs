using System;
using System.Collections.Generic;
using jyApi.Models;

namespace jyApi.Repository
{
    public class MockEmployeeRepo : IEmployeeRepository
    {

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
    }
}
