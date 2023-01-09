using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Internship_Recommendation_System.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Add Company
        [Authorize]
        [HttpGet]
        public ActionResult AddCompany()
        {
            return View();
        }

        // POST: Add Company
        [HttpPost]
        public ActionResult AddCompany(CompanyViewModel company)
        {
            using (IRSEntities db = new IRSEntities())
            {
                if (db.Companies.Where(u => u.CompanyName.Contains(company.CompanyName)).FirstOrDefault() != null)
                {
                    return Json("Company already available!", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Company newCompany = new Company
                    {
                        CompanyName = company.CompanyName,
                        CompanyAddress = company.CompanyAddress,
                        HRManager = company.HRManager,
                        Email = company.Email,
                        PhoneNo = company.PhoneNo,                        
                    };
                    db.Companies.Add(newCompany);
                    db.SaveChanges();
                    return Json("Company has been added to the Database!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewCompanies()
        {
            List<CompanyViewModel> companiesList = new List<CompanyViewModel>();
            using (IRSEntities db = new IRSEntities())
            {
                var companies = db.Companies.ToList();
                foreach (var company in companies)
                {
                    CompanyViewModel newCompany = new CompanyViewModel();
                    newCompany.CompanyID = company.CompanyID;
                    newCompany.CompanyName = company.CompanyName;
                    newCompany.CompanyAddress = company.CompanyAddress;
                    companiesList.Add(newCompany);
                }
            }
            return View(companiesList);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteCompany(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                Company company = db.Companies.Find(id);
                if (company == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.Companies.Remove(company);
                    db.SaveChanges();
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewCompanies", "Company") });
        }
    }
}