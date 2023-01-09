using Internship_Recommendation_System.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Internship_Recommendation_System.ViewModels
{
    public class StudentViewModel
    {
        public int UserID { get; set; }

        [Display(Name = "Index Number")]
        [Required(ErrorMessage = "Please Enter University ID Number!")]
        [DataType(DataType.Text)]
        public string IndexNo { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter Your First Name!")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last Name!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

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

        [Required(ErrorMessage = "Please Enter Your University Email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        [Display(Name = "University")]
        [Required(ErrorMessage = "Please Select Your University!")]
        public int UniversityID { get; set; }

        [Display(Name = "Approval Status")]
        public bool IsApproved { get; set; }

        public string DegreeName { get; set; }
    }
}