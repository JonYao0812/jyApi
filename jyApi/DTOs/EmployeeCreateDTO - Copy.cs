using System.ComponentModel.DataAnnotations;

namespace jyApi.DTOs
{
    public class EmployeeCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Location { get; set; }
    }
}