using AutoMapper;
using jyApi.DTOs;
using jyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jyApi.Profiles
{
    public class jyProfile : Profile
    {

        public jyProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<EmployeeUpdateDTO, Employee>().ReverseMap();
           // CreateMap<Employee, EmployeeUpdateDTO>();
        }
    }
}
