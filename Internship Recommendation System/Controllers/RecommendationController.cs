using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Internship_Recommendation_System.Controllers
{
    public class RecommendationController : Controller
    {
        // GET: Get Recommendation
        [HttpGet]
        [Authorize]
        public ActionResult GetRecommendation()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                using (IRSEntities db = new IRSEntities())
                {
                    ViewBag.UniYearID = new SelectList(db.UniYears, "UniYearID", "UniYearVal").ToList();
                    ViewBag.JobID = new SelectList(db.Jobs, "JobID", "JobPosition").ToList();
                    ViewBag.ExpectedPeriodID = new SelectList(db.ExpectedPeriods, "ExpectedPeriodID", "PeriodDescription").ToList();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetRecommendation(RecommendationViewModel recommendation)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                CurrentUserViewModel currentUser = JsonConvert.DeserializeObject<CurrentUserViewModel>(authTicket.UserData);
                int studentID = currentUser.UserID;
                using (IRSEntities db = new IRSEntities())
                {
                    if (recommendation.IncludeBioData)
                    {
                        var BioDataList = db.Students.Where(u => u.StudentID == studentID).Select(u => new { u.DateOfBirth, u.Gender }).ToList();
                        var years = DateTime.Now.Year - BioDataList[0].DateOfBirth.Year;
                        if (years < 18)
                        {
                            recommendation.AgeID = 1;
                        }
                        else if (18 <= years && years <= 20)
                        {
                            recommendation.AgeID = 2;
                        }
                        else if (21 <= years && years <= 23)
                        {
                            recommendation.AgeID = 3;
                        }
                        else if (24 <= years && years <= 26)
                        {
                            recommendation.AgeID = 4;
                        }
                        else if (26 < years)
                        {
                            recommendation.AgeID = 5;
                        }
                        recommendation.Gender = BioDataList[0].Gender;
                    }
                    if (recommendation.IncludeAcademicData)
                    {
                        var AcademicDataList = db.Students.Where(u => u.StudentID == studentID).Select(u => new { u.UniversityID_FK, u.DegreeID_FK }).ToList();
                        recommendation.UniID = AcademicDataList[0].UniversityID_FK;
                        recommendation.DegreeID = AcademicDataList[0].DegreeID_FK;
                    }
   

                    var results = db.getRecommendation(
                        recommendation.JobID, 
                        recommendation.UniID,
                        recommendation.DegreeID,
                        recommendation.UniYearID, 
                        recommendation.IsCompleted,
                        recommendation.AgeID,
                        recommendation.Gender,
                        recommendation.ExpectedPeriodID,
                        recommendation.Parameter1, recommendation.Parameter2, recommendation.Parameter3, recommendation.Parameter4, recommendation.Parameter5,
                        recommendation.Parameter6, recommendation.Parameter7, recommendation.Parameter8, recommendation.Parameter9, recommendation.Parameter10).OrderByDescending(e => e.PreferenceScore).ToList();
                    string jsonResult = JsonConvert.SerializeObject(results);
                    return Json(jsonResult);
                }
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
    }
}