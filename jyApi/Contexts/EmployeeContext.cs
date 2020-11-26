using jyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace jyApi.Contexts
{
    public class EmployeeContext : DbContext
    {

     public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options){}

     public DbSet<Employee> Employees {get;set;}
    }
}
