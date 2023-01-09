using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class DegreeViewModel
    {
        [Display(Name = "Degree ID")]
        public int DegreeID { get; set; }

        [Display(Name = "Degree Name")]
        [Required(ErrorMessage = "Please Enter Degree Name!")]
        public string DegreeName { get; set; }

        [Display(Name = "Degree Description")]
        [StringLength(200, ErrorMessage = "The Degree Description cannot exceed 200 characters!")]
        [DataType(DataType.MultilineText)]
        public string DegreeDescription { get; set; }
    }
}