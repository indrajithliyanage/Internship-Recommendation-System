using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Internship_Recommendation_System.Controllers
{
    public class JobPositionController : Controller
    {
        // GET: Add Position
        [Authorize]
        [HttpGet]
        public ActionResult AddPosition()
        {
            return View();
        }

        // POST: Add Position
        [Authorize]
        [HttpPost]
        public ActionResult AddPosition(JobPositionViewModel job)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                using (IRSEntities db = new IRSEntities())
                {
                    if (db.Jobs.Where(u => u.JobPosition.Contains(job.JobPosition)).FirstOrDefault() != null)
                    {
                        return Json("Job Position Already Available!", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Job newJob = new Job
                        {
                            JobPosition = job.JobPosition,
                            JobDescription = job.JobDescription,
                        };
                        db.Jobs.Add(newJob);
                        db.SaveChanges();
                        return Json("Job Position has been added to the Database!", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewPositions()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                List<JobPositionViewModel> jobList = new List<JobPositionViewModel>();
                using (IRSEntities db = new IRSEntities())
                {
                    var jobs = db.Jobs.ToList();
                    foreach (var job in jobs)
                    {
                        JobPositionViewModel newJob = new JobPositionViewModel();
                        newJob.JobID = job.JobID;
                        newJob.JobPosition = job.JobPosition;
                        newJob.JobDescription = job.JobDescription;
                        jobList.Add(newJob);
                    }
                }
                return View(jobList);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
               
        }
    }
}