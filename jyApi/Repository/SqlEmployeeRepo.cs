using jyApi.Contexts;
using jyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jyApi.Repository
{
    public class SqlEmployeeRepo : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public SqlEmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void CreateEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            _context.Employees.Add(emp);
        }

        public void DeleteEmployee(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }
            _context.Employees.Remove(emp);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee emp)
        {
        }
    }
}
