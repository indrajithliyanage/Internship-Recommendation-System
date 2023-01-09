using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Your University Email!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password!")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 character in length!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}