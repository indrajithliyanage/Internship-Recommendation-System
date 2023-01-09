using Internship_Recommendation_System.Models;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Internship_Recommendation_System.ViewModels
{
    public class IntExpViewModel
    {
        public int IntExpID { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Select Your Company Name!")]
        public int CompanyID_FK { get; set; }

        [Display(Name = "Internship Position")]
        [Required(ErrorMessage = "Please Select Your Internship Position!")]
        public int JobID_FK { get; set; }

        [Display(Name = "Internship Started Date")]
        [Required(ErrorMessage = "Please Enter Internship Started Year!")]
        [DataType(DataType.Date)]
        public System.DateTime YearStarted { get; set; }

        [Display(Name = "Internship Started University Year")]
        [Required(ErrorMessage = "Please Select Internship Started University Year!")]
        public int UniversityYear_FK { get; set; }

        [Display(Name = "Internship Period in Months")]
        [Required(ErrorMessage = "Please Enter Internship Period in Months!")]
        [Range(1, 24, ErrorMessage = "Value must be between 1 and 24.")]
        public int InternshipPeriod { get; set; }

        [Display(Name = "Did You Complete the Internship?")]
        public bool IsCompleted { get; set; }

        public string AcceptanceLetterPath { get; set; }

        [Display(Name = "Internship Offer Letter")]
        [Required(ErrorMessage = "Please Upload Your Internship Acceptance/Offer Letter!")]
        public HttpPostedFileBase AcceptanceLetter { get; set; }

        public string ServiceLetterPath { get; set; }

        [Display(Name = "Internship Service Letter")]
        public HttpPostedFileBase ServiceLetter { get; set; }

        [Display(Name = "Flexibility to Attend Personal/Academic Activities")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter1 { get; set; }

        [Display(Name = "Getting a Real Job Experience & learning opportunities")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter2 { get; set; }

        [Display(Name = "Internship Training was Related to Degree Course Modules")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter3 { get; set; }

        [Display(Name = "Carrying out Reasonable Evaluation Procedures")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter4 { get; set; }

        [Display(Name = "Supervisor Support, Feedback, Recognition & Interpersonal Relationship")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter5 { get; set; }

        [Display(Name = "Co-Workers Support, Feedback, Recognition & Interpersonal Relationship")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter6 { get; set; }

        [Display(Name = "Significance/Importance of Tasks given")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter7 { get; set; }

        [Display(Name = "Attractive Allowances")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter8 { get; set; }

        [Display(Name = "Facilities & Work Environment")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter9 { get; set; }

        [Display(Name = "Opening a Path to Career Development")]
        [Required(ErrorMessage = "Please Input Your Ratings!")]
        public int Parameter10 { get; set; }

        [Display(Name = "Approval Status")]
        public bool IsApproved { get; set; }

        [Display(Name = "Student ID")]
        public int StudentID_FK { get; set; }

        public virtual Company Company { get; set; }
        public virtual Job Job { get; set; }
        public virtual Student Student { get; set; }
        public virtual UniYear UniYear { get; set; }
    }
}