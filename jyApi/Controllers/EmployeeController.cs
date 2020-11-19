using System;
using System.Collections.Generic;
using System.Linq;
using jyApi.Models;
using jyApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace jyApi.Controllers
{ 

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeesList = _repository.GetAllEmployees();

            return Ok(employeesList);
           
        }


        //Get api/employee/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById([FromRoute] int id)
        {

            var employee = _repository.GetEmployeeById(id);
            return Ok(employee);
          
        }

    }
}
