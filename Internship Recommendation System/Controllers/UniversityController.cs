using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Internship_Recommendation_System.Controllers
{
    public class UniversityController : Controller
    {
        // GET: Add University
        [Authorize]
        [HttpGet]
        public ActionResult AddUniversity()
        {
            return View();
        }

        // POST: Add University
        [Authorize]
        [HttpPost]
        public ActionResult AddUniversity(UniversityViewModel university)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                using (IRSEntities db = new IRSEntities())
                {
                    if (db.Universities.Where(u => u.UniversityName.Contains(university.UniversityName)).FirstOrDefault() != null)
                    {
                        return Json("University is Already Available!", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        University newUniversity = new University
                        {
                            UniversityName = university.UniversityName,
                            UniversityAddress = university.UniversityAddress
                        };
                        db.Universities.Add(newUniversity);
                        db.SaveChanges();
                        return Json("University has been added to the Database!", JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewUniversities()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                List<UniversityViewModel> uniList = new List<UniversityViewModel>();
                using (IRSEntities db = new IRSEntities())
                {
                    var universities = db.Universities.ToList();
                    foreach (var university in universities)
                    {
                        UniversityViewModel newUni = new UniversityViewModel();
                        newUni.UniversityID = university.UniversityID;
                        newUni.UniversityName = university.UniversityName;
                        newUni.UniversityAddress = university.UniversityAddress;
                        uniList.Add(newUni);
                    }
                }
                return View(uniList);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteUniversity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                University university = db.Universities.Find(id);
                if (university == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.Universities.Remove(university);
                    db.SaveChanges();
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewUniversities", "University") });
        }
    }
}