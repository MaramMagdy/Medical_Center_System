using System.ComponentModel.DataAnnotations;

namespace Medical_Center_System.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Display Name cannot be longer than 100 characters")]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmedPassword { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(11, ErrorMessage = "Phone number cannot be longer than 11 digits")]
        public string PhoneNumber { get; set; }

    }


}
