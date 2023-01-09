using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class JobPositionViewModel
    {
        [Display(Name = "Job ID")]
        public int JobID { get; set; }

        [Display(Name = "Job Position")]
        [Required(ErrorMessage = "Please Enter Job Position!")]
        public string JobPosition { get; set; }

        [Display(Name = "Job Description")]
        [Required(ErrorMessage = "Please Enter Job Description!")]
        [StringLength(200, ErrorMessage = "The Job Description cannot exceed 200 characters!")]
        [DataType(DataType.MultilineText)]
        public string JobDescription { get; set; }
    }
}