using jyApi.Models;
using System;
using System.Collections.Generic;

namespace jyApi.Repository
{
    public interface IEmployeeRepository
    {

        bool SaveChanges();
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(Employee emp);






    }
}
