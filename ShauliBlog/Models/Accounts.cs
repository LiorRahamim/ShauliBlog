using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShauliBlog.Models
{
    public class RegisterModel
    {
        [Key]
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The confirmation password doesn't match the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        /**
         * Extra layer that helps identifying the user
         */
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Question")]
        public string AutenticationQuestion { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Answer")]
        public string AutenticationAnswer { get; set; }
    }

    public class ForgotPasswordModel
    {
        [Key]
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }

    public class ForgotPasswordAuthenticationModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Question")]
        public string AutenticationQuestion { get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Answer")]
        public string AutenticationAnswer { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The confirmation password doesn't match the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Key]
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}