using System;
using System.ComponentModel.DataAnnotations;

namespace jyApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }


        [Required]
        public int Location { get; set; }

       /* [Required]
        public int Subsidiary { get; set; }

        [Required]
        public int Practice { get; set; }

        [Required]
        public int EmployeeType { get; set; }

        [Required]
        public DateTime HireDate { get; set; }*/






    }
}
