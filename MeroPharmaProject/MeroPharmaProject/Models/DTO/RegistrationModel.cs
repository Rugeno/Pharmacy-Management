using System.ComponentModel.DataAnnotations;

namespace MeroPharmaProject.Models.DTO
{
    public class RegistrationModel
    {
        [Key]
        public Guid RegistrationId { get; set; }
       
        [Required]
        public string Name { get; set; }

        public long Salary { get; set; }

        public string Address { get; set; }
        public DateTime JoinedDate { get; set; }

        [Required(ErrorMessage ="Please enter you contact")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Minimum length 6 and must contain  1 Uppercase,1 lowercase, 1 special character and 1 digit")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        public string? Role { get; set; }

    }
}