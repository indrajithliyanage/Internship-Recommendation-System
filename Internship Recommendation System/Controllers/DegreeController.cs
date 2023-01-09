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
    public class DegreeController : Controller
    {
        // GET: Add Degree
        [Authorize]
        [HttpGet]
        public ActionResult AddDegree()
        {
            return View();
        }

        // POST: Add Degree
        [Authorize]
        [HttpPost]
        public ActionResult AddDegree(DegreeViewModel degree)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                using (IRSEntities db = new IRSEntities())
                {
                    if (db.Degrees.Where(u => u.DegreeName.Contains(degree.DegreeName)).FirstOrDefault() != null)
                    {
                        return Json("Degree Already Available!", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Degree newDegree = new Degree
                        {
                            DegreeName = degree.DegreeName,
                            DegreeDescription = degree.DegreeDescription
                        };
                        db.Degrees.Add(newDegree);
                        db.SaveChanges();
                        return Json("Degree has been added to the Database!", JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewDegrees()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                List<DegreeViewModel> degreeList = new List<DegreeViewModel>();
                using (IRSEntities db = new IRSEntities())
                {
                    var degrees = db.Degrees.ToList();
                    foreach (var degree in degrees)
                    {
                        DegreeViewModel newDegree = new DegreeViewModel();
                        newDegree.DegreeID = degree.DegreeID;
                        newDegree.DegreeName = degree.DegreeName;
                        newDegree.DegreeDescription = degree.DegreeDescription;                        
                        degreeList.Add(newDegree);
                    }
                }
                return View(degreeList);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteDegree(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                Degree degree = db.Degrees.Find(id);
                if (degree == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.Degrees.Remove(degree);
                    db.SaveChanges();
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewDegrees", "Degree") });
        }
    }
}