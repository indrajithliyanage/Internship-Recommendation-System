using Internship_Recommendation_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class CGUnitViewModel
    {
        public int CGUnitID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter CG Unit Head's First Name!")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter CG Unit Head's Last Name!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your CG Unit Email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your University Address!")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter CG Unit Phone Number!")]
        [DataType(DataType.Text)]
        public string PhoneNo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Role { get; set; }

        [Display(Name = "University")]
        [Required(ErrorMessage = "Please Select Your University!")]
        public int UniversityID { get; set; }

        [Display(Name = "University")]
        public string UniName { get; set; }

        [Display(Name = "Approval Status")]
        public bool IsApproved { get; set; }

        public virtual University University { get; set; }
    }
}