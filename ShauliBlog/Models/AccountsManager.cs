using System.ComponentModel.DataAnnotations;

namespace ShauliBlog.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "identity number")]
        public string IDNumber { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The confirmation password doesn't match the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}