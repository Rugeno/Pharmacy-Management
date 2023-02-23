using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MeroPharma.Models
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "Please enter your Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please enter the salary")]
        public long Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Primary Contact")]
        [Required(ErrorMessage = "Primary Contact is Required.")]
        public string Contact { get; set; }
        
    }
}
