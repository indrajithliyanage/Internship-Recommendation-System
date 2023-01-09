using System.ComponentModel.DataAnnotations;

namespace Internship_Recommendation_System.ViewModels
{
    public class UniversityViewModel
    {
        [Display(Name = "University ID")]
        public int UniversityID { get; set; }

        [Display(Name = "University Name")]
        [Required(ErrorMessage = "Please Enter University Name!")]
        public string UniversityName { get; set; }

        [Display(Name = "University Address")]
        [Required(ErrorMessage = "Please Enter University Address!")]
        [DataType(DataType.MultilineText)]
        public string UniversityAddress { get; set; }
    }
}