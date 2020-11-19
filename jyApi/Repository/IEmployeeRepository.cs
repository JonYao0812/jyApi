using System;
using System.Collections.Generic;
using jyApi.Models;

namespace jyApi.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);




    }
}
