using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Internship_Recommendation_System.Controllers
{
    public class CGUController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult ViewCGUs()
        {
            List<CGUnitViewModel> cguList = new List<CGUnitViewModel>();
            using (IRSEntities db = new IRSEntities())
            {
                var cgus = db.CGUnits.Include(e => e.University).ToList();
                foreach (var cgUnit in cgus)
                {
                    CGUnitViewModel newCGUnit = new CGUnitViewModel();
                    newCGUnit.University = cgUnit.University;
                    newCGUnit.CGUnitID = cgUnit.CGUnitID;
                    newCGUnit.Address = cgUnit.Address;
                    newCGUnit.Email = cgUnit.Email;
                    newCGUnit.PhoneNo = cgUnit.PhoneNo;
                    newCGUnit.FirstName = cgUnit.FirstName;
                    newCGUnit.LastName = cgUnit.LastName;
                    newCGUnit.UniName = cgUnit.University.UniversityName;
                    newCGUnit.IsApproved = cgUnit.IsApproved;
                    cguList.Add(newCGUnit);
                }
            }
            return View(cguList);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ApproveCGU(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                CGUnit cgUnit = db.CGUnits.Find(id);
                if (cgUnit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    cgUnit.IsApproved = true;
                    db.Entry(cgUnit).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewCGUs", "CGU") });
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteCGU(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                CGUnit cgUnit = db.CGUnits.Find(id);
                if (cgUnit == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.CGUnits.Remove(cgUnit);
                    db.SaveChanges();
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewCGUs", "CGU") });
        }
    }
}