using System.ComponentModel.DataAnnotations;

namespace MeroPharma.Models.Domain
{
    public class Employee
    {
        [Key]
        public Guid EmployeeID { get; set; }

        public string? EmployeeName { get; set; }

        public long Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Contact { get; set; }
    }
}
