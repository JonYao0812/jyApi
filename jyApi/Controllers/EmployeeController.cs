using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using jyApi.DTOs;
using jyApi.Models;
using jyApi.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace jyApi.Controllers
{ 

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeesList = _repository.GetAllEmployees();

            return Ok(employeesList);
           
        }


        //Get api/employee/{id}
        [HttpGet("{id}", Name="GetEmployeeById")]
        public ActionResult<EmployeeDTO> GetEmployeeById([FromRoute] int id)
        {

            var employee = _repository.GetEmployeeById(id);

            if( employee != null)
            {
                return Ok(_mapper.Map<EmployeeDTO>(employee));
            }
            return NotFound();
        }

        //Post api/employee
        [HttpPost]
        public ActionResult<EmployeeUpdateDTO> CreateEmployee(EmployeeCreateDTO employeeCreateDTO)
        {

            var employeeToCreate = _mapper.Map<Employee>(employeeCreateDTO);
            _repository.CreateEmployee(employeeToCreate);
            _repository.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeDTO>(employeeToCreate);

            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);

        }

        //Put api/employee/{id}
        [HttpPut("{id}")]
        public ActionResult<EmployeeUpdateDTO> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDTO)
        {

            var employeeToUpdate = _repository.GetEmployeeById(id);
            if( employeeToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(employeeUpdateDTO, employeeToUpdate);
            _repository.SaveChanges();
            return Ok(employeeUpdateDTO);
        }


        //Patch api/employee/{id}
        [HttpPatch("{id}")]
        public ActionResult<EmployeeUpdateDTO> PatchEmployee(int id, JsonPatchDocument<EmployeeUpdateDTO> patchDoc )
        {
            var employeeToPatch = _repository.GetEmployeeById(id);
            if (employeeToPatch == null)
            {
                return NotFound();
            }

            var employeeUpdateDto = _mapper.Map<EmployeeUpdateDTO>(employeeToPatch);
            patchDoc.ApplyTo(employeeUpdateDto, ModelState);

            if (!TryValidateModel(employeeUpdateDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeUpdateDto, employeeToPatch);
            _repository.UpdateEmployee(employeeToPatch);
            _repository.SaveChanges();
            return Ok(employeeToPatch);

        }

        //Delete api/employee/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeToDelete = _repository.GetEmployeeById(id);
            if (employeeToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteEmployee(employeeToDelete);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
