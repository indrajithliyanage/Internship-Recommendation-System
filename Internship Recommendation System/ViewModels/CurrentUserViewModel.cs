using Microsoft.Ajax.Utilities;

namespace Internship_Recommendation_System.ViewModels
{
    public class CurrentUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int UniversityID { get; set; }
        public int UserID { get; set; }
    }
}