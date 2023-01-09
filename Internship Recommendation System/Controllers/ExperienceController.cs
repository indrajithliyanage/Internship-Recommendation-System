using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Internship_Recommendation_System.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Add Experience
        [Authorize]
        [HttpGet]
        public ActionResult AddExperience()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                using (IRSEntities db = new IRSEntities())
                {
                    ViewBag.UniversityYear_FK = new SelectList(db.UniYears, "UniYearID", "UniYearVal").ToList();
                    ViewBag.CompanyID_FK = new SelectList(db.Companies, "CompanyID", "CompanyName").ToList();
                    ViewBag.JobID_FK = new SelectList(db.Jobs, "JobID", "JobPosition").ToList();
                    ViewBag.InternshipPeriod = new SelectList(db.ExpectedPeriods, "ExpectedPeriodID", "PeriodDescription").ToList();
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        // POST: Add Experience
        [Authorize]
        [HttpPost]
        public ActionResult AddExperience(IntExpViewModel experience)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                if (experience.AcceptanceLetter != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(experience.AcceptanceLetter.FileName);
                    string extension = Path.GetExtension(experience.AcceptanceLetter.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    experience.AcceptanceLetterPath = "~/Uploads/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
                    experience.AcceptanceLetter.SaveAs(fileName);
                }
                if (experience.ServiceLetter != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(experience.ServiceLetter.FileName);
                    string extension = Path.GetExtension(experience.ServiceLetter.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    experience.ServiceLetterPath = "~/Uploads/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    Directory.CreateDirectory(Server.MapPath("~/Uploads/"));
                    experience.ServiceLetter.SaveAs(fileName);
                }

                using (IRSEntities db = new IRSEntities())
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var identity = (FormsIdentity)User.Identity;
                        var userData = identity.Ticket.UserData;
                        if (!string.IsNullOrEmpty(userData))
                        {
                            CurrentUserViewModel currentUser = JsonConvert.DeserializeObject<CurrentUserViewModel>(userData);
                            experience.StudentID_FK = db.Students.Where(u => u.Email == currentUser.Email).FirstOrDefault().StudentID;
                        }
                    }

                    InternshipExperience internshipExperience = new InternshipExperience
                    {
                        StudentID_FK = experience.StudentID_FK,
                        CompanyID_FK = experience.CompanyID_FK,
                        JobID_FK = experience.JobID_FK,
                        YearStarted = experience.YearStarted,
                        UniversityYear_FK = experience.UniversityYear_FK,
                        InternshipPeriod = experience.InternshipPeriod,
                        IsCompleted = experience.IsCompleted,
                        AcceptanceLetterPath = experience.AcceptanceLetterPath,
                        ServiceLetterPath = experience.ServiceLetterPath,
                        Parameter1 = experience.Parameter1,
                        Parameter2 = experience.Parameter2,
                        Parameter3 = experience.Parameter3,
                        Parameter4 = experience.Parameter4,
                        Parameter5 = experience.Parameter5,
                        Parameter6 = experience.Parameter6,
                        Parameter7 = experience.Parameter7,
                        Parameter8 = experience.Parameter8,
                        Parameter9 = experience.Parameter9,
                        Parameter10 = experience.Parameter10,
                        IsApproved = false,
                    };
                    db.InternshipExperiences.Add(internshipExperience);
                    db.SaveChanges();
                    return Json("Your expereince has been added! A person from your Career Guidance Unit will Approve it!", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        // GET: View Experiences
        [Authorize]
        [HttpGet]
        public ActionResult ViewExperiences()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                CurrentUserViewModel currentUser = JsonConvert.DeserializeObject<CurrentUserViewModel>(authTicket.UserData);
                if (currentUser.Role != null && currentUser.Role == "CGU")
                {
                    List<IntExpViewModel> experienceList = new List<IntExpViewModel>();
                    using (IRSEntities db = new IRSEntities())
                    {
                        var expereinces = db.InternshipExperiences.Include(e => e.Company).Include(e => e.Student).Include(e => e.Job).Where(e => e.Student.UniversityID_FK == currentUser.UniversityID).ToList();
                        foreach (var experience in expereinces)
                        {
                            IntExpViewModel newExp = new IntExpViewModel();
                            newExp.Company = experience.Company;
                            newExp.Student = experience.Student;
                            newExp.Job = experience.Job;
                            newExp.UniYear = experience.UniYear;
                            newExp.IntExpID = experience.ExpID;
                            newExp.CompanyID_FK = experience.CompanyID_FK;
                            newExp.JobID_FK = experience.JobID_FK;
                            newExp.YearStarted = experience.YearStarted;
                            newExp.UniversityYear_FK = experience.UniversityYear_FK;
                            newExp.InternshipPeriod = experience.InternshipPeriod;
                            newExp.IsCompleted = experience.IsCompleted;
                            newExp.IsApproved = experience.IsApproved;
                            newExp.AcceptanceLetterPath = experience.AcceptanceLetterPath;
                            newExp.ServiceLetterPath = experience.ServiceLetterPath;
                            newExp.StudentID_FK = experience.StudentID_FK;
                            experienceList.Add(newExp);
                        }
                    }
                    ViewBag.Role = "Manager";
                    return View(experienceList);
                }
                else
                {
                    List<IntExpViewModel> experienceList = new List<IntExpViewModel>();
                    using (IRSEntities db = new IRSEntities())
                    {
                        var expereinces = db.InternshipExperiences.Include(e => e.Company).Include(e => e.Student).Include(e => e.Job).Where(e => e.StudentID_FK == currentUser.UserID).ToList();
                        foreach (var experience in expereinces)
                        {
                            IntExpViewModel newExp = new IntExpViewModel();
                            newExp.Company = experience.Company;
                            newExp.Student = experience.Student;
                            newExp.Job = experience.Job;
                            newExp.UniYear = experience.UniYear;
                            newExp.IntExpID = experience.ExpID;
                            newExp.CompanyID_FK = experience.CompanyID_FK;
                            newExp.JobID_FK = experience.JobID_FK;
                            newExp.YearStarted = experience.YearStarted;
                            newExp.UniversityYear_FK = experience.UniversityYear_FK;
                            newExp.InternshipPeriod = experience.InternshipPeriod;
                            newExp.IsCompleted = experience.IsCompleted;
                            newExp.IsApproved = experience.IsApproved;
                            newExp.AcceptanceLetterPath = experience.AcceptanceLetterPath;
                            newExp.ServiceLetterPath = experience.ServiceLetterPath;
                            newExp.StudentID_FK = experience.StudentID_FK;
                            newExp.Parameter1 = experience.Parameter1;
                            newExp.Parameter2 = experience.Parameter2;
                            newExp.Parameter3 = experience.Parameter3;
                            newExp.Parameter4 = experience.Parameter4;
                            newExp.Parameter5 = experience.Parameter5;
                            newExp.Parameter6 = experience.Parameter6;
                            newExp.Parameter7 = experience.Parameter7;
                            newExp.Parameter8 = experience.Parameter8;
                            newExp.Parameter9 = experience.Parameter9;
                            newExp.Parameter10 = experience.Parameter10;
                            experienceList.Add(newExp);
                        }
                    }
                    ViewBag.Role = "User";
                    return View(experienceList);
                }
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }            
        }

        [Authorize]
        [HttpPost]
        public ActionResult ApproveExperience(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                InternshipExperience experience = db.InternshipExperiences.Find(id);
                if (experience == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    experience.IsApproved = true;
                    db.Entry(experience).State = EntityState.Modified;
                    db.SaveChanges();
                    db.AddApprovedEXPs(id);
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewExperiences", "Experience") });
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteExperience(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                InternshipExperience experience = db.InternshipExperiences.Find(id);
                if (experience == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.InternshipExperiences.Remove(experience);
                    db.SaveChanges();
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewExperiences", "Experience") });
        }
    }
}