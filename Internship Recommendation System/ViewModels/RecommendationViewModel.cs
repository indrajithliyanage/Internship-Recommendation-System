using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class RecommendationViewModel
    {
        [Display(Name = "Internship Position")]
        [Required(ErrorMessage = "Please Select an Internship Position!")]
        public int JobID { get; set; }

        [Display(Name = "Expecting Internship Period")]
        public int? ExpectedPeriodID { get; set; }

        public int UniID { get; set; }

        public int DegreeID { get; set; }

        [Display(Name = "Current University Year")]
        public int? UniYearID { get; set; }

        [Display(Name = "Include Only Completed Internship Records")]
        public bool IsCompleted { get; set; }

        public int AgeID { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Include My Bio Data for Recommendation")]
        public bool IncludeBioData { get; set; }

        [Display(Name = "Include My Academic Data for Recommendation")]
        public bool IncludeAcademicData { get; set; }

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
    }
}