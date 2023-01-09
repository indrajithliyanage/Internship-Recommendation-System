using System;
using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "Index Number")]
        [Required(ErrorMessage = "Please Enter University ID Number!")]
        [DataType(DataType.Text)]
        public string IndexNo { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter Your First Name!")]
        [DataType(DataType.Text)]
        public string StuFirstName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter Your First Name!")]
        [DataType(DataType.Text)]
        public string CguFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last Name!")]
        [DataType(DataType.Text)]
        public string StuLastName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last Name!")]
        [DataType(DataType.Text)]
        public string CguLastName { get; set; }

        [Required(ErrorMessage = "Please Select Your Gender!")]
        [DataType(DataType.Text)]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please Enter Your Date of Birth!")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Display(Name = "Degree")]
        [Required(ErrorMessage = "Please Select Your Degree!")]
        public int DegreeID { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Enter Your University Email!")]
        [DataType(DataType.EmailAddress)]
        public string StuEmail { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please Enter Your University Email!")]
        [DataType(DataType.EmailAddress)]
        public string CguEmail { get; set; }

        [Required]
        public string Role { get; set; }

        [Display(Name = "University")]
        [Required(ErrorMessage = "Please Select Your University!")]
        public int StuUniversityID { get; set; }

        [Display(Name = "University")]
        [Required(ErrorMessage = "Please Select Your University!")]
        public int CguUniversityID { get; set; }

        [Required(ErrorMessage = "Please Enter Your University Address!")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name = "Phone No.")]
        [Required(ErrorMessage = "Please Enter CG Unit Phone Number!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a Valid Phone Number!")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please enter a Valid Phone Number!")]
        public string PhoneNo { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter A New Password!")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 character in length!")]
        public string StuPassword { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter A New Password!")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 character in length!")]
        public string CguPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("StuPassword", ErrorMessage = "Passwords should be same!")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Selected Password!")]
        public string StuConfirmPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("CguPassword", ErrorMessage = "Passwords should be same!")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Selected Password!")]
        public string CguConfirmPassword { get; set; }
    }
}