using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class CompanyViewModel
    {
        [Display(Name = "Company ID")]
        public int CompanyID { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Enter Company Name!")]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [Display(Name = "HR Manager's Name")]  
        [DataType(DataType.Text)]
        public string HRManager { get; set; }

        [Display(Name = "Company Email")]        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Company Phone No.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid Phone No.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        [Display(Name = "Company Address")]
        [Required(ErrorMessage = "Please Enter Company Address!")]
        [DataType(DataType.MultilineText)]
        public string CompanyAddress { get; set; }
    }
}