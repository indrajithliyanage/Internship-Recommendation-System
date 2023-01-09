using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Internship_Recommendation_System.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email, Password, RememberMe")] LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return Json("Form Data Could Not Be Validated!", JsonRequestBehavior.AllowGet);
            }
            using (IRSEntities db = new IRSEntities())
            {
                if (db.Students.Where(u => u.Email == login.Email).FirstOrDefault() != null)
                {
                    string encryptedPassword = MD5StringGenerator.GetMD5(login.Password);
                    Student student = db.Students.Where(u => u.Email == login.Email && u.Password == encryptedPassword).FirstOrDefault();
                    if (student != null && student.IsApproved == true)
                    {
                        StudentViewModel studentData = new StudentViewModel
                        {
                            UserID = student.StudentID,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Gender = student.Gender,
                            DateofBirth = student.DateOfBirth,
                            DegreeID = student.DegreeID_FK,
                            Email = student.Email,
                            IndexNo = student.IndexNo,
                            Role = student.Role,
                            UniversityID = student.University.UniversityID
                        };

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                            student.StudentID.ToString(),
                            DateTime.Now,
                            DateTime.Now.AddMinutes(5),
                            login.RememberMe,
                            JsonConvert.SerializeObject(studentData)
                        );

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);
                        return Json(new { redirectToUrl = Url.Action("Index", "Home") });
                    }
                    else if (student != null && student.IsApproved != true)
                    {
                        return Json("Your account has not yet Approved!", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Email or Password is Incorrect!", JsonRequestBehavior.AllowGet);
                    }
                }
                else if (db.CGUnits.Where(u => u.Email == login.Email).FirstOrDefault() != null)
                {
                    string encryptedPassword = MD5StringGenerator.GetMD5(login.Password);
                    CGUnit cgunit = db.CGUnits.Where(u => u.Email == login.Email && u.Password == encryptedPassword).FirstOrDefault();
                    if (cgunit != null && cgunit.IsApproved == true)
                    {
                        CGUnitViewModel cgunitData = new CGUnitViewModel
                        {
                            CGUnitID = cgunit.CGUnitID,
                            FirstName = cgunit.FirstName,
                            LastName = cgunit.LastName,
                            Email = cgunit.Email,
                            Address = cgunit.Address,
                            PhoneNo = cgunit.PhoneNo,
                            Role = cgunit.Role,
                            UniversityID = cgunit.University.UniversityID
                        };

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                            cgunit.CGUnitID.ToString(),
                            DateTime.Now,
                            DateTime.Now.AddMinutes(5),
                            login.RememberMe,
                            JsonConvert.SerializeObject(cgunitData)
                        );

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);
                        return Json(new { redirectToUrl = Url.Action("Index", "Home") });
                    }
                    else if (cgunit != null && cgunit.IsApproved != true)
                    {
                        return Json("Your account has not yet Approved!", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Email or Password is Incorrect!", JsonRequestBehavior.AllowGet);
                    }
                }
                else if (db.Users.Where(u => u.Email == login.Email).FirstOrDefault() != null)
                {
                    string encryptedPassword = MD5StringGenerator.GetMD5(login.Password);
                    User user = db.Users.Where(u => u.Email == login.Email && u.Password == encryptedPassword).FirstOrDefault();
                    if (user != null)
                    {
                        UserViewModel userData = new UserViewModel
                        {
                            UserID = user.UserID,
                            Email = user.Email,
                            Role = user.Role,
                            UserName = user.UserName
                        };

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                            userData.UserID.ToString(),
                            DateTime.Now,
                            DateTime.Now.AddMinutes(5),
                            login.RememberMe,
                            JsonConvert.SerializeObject(userData)
                        );

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);
                        return Json(new { redirectToUrl = Url.Action("Index", "Home") });
                    }
                    else
                    {
                        return Json("Email or Password is Incorrect!", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("Account doesn't exsist!", JsonRequestBehavior.AllowGet);
                }
            }
        }

        // GET: Auth/Logout
        [Authorize]
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // GET: Register
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            using (IRSEntities db = new IRSEntities())
            {
                var uniList = new SelectList(db.Universities, "UniversityID", "UniversityName").ToList();
                ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "DegreeName").ToList();
                ViewBag.StuUniversityID = uniList;
                ViewBag.CguUniversityID = uniList;
            }
            return View();
        }

        // POST: Auth/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            using (IRSEntities db = new IRSEntities())
            {
                if (db.Students.Where(u => u.Email == register.StuEmail).FirstOrDefault() != null || db.CGUnits.Where(u => u.Email == register.CguEmail).FirstOrDefault() != null)
                {
                    return Json("You already have an account! Try Login in!", JsonRequestBehavior.AllowGet);
                }
                else if (register.Role == "STU" && db.Students.Where(u => u.Email == register.StuEmail).FirstOrDefault() == null)
                {
                    string encryptedPassword = MD5StringGenerator.GetMD5(register.StuPassword);
                    Student student = new Student
                    {
                        Email = register.StuEmail,
                        FirstName = register.StuFirstName,
                        LastName = register.StuLastName,
                        UniversityID_FK = register.StuUniversityID,
                        IndexNo = register.IndexNo,
                        Gender = register.Gender,
                        DateOfBirth = register.DateofBirth,
                        DegreeID_FK = register.DegreeID,
                        Password = encryptedPassword,
                        Role = register.Role,
                    };
                    db.Students.Add(student);
                    db.SaveChanges();
                    return Json("Your account has been created! A person from your Career Guidance Unit will Approve it!", JsonRequestBehavior.AllowGet);
                }
                else if (register.Role == "CGU" && db.CGUnits.Where(u => u.Email == register.CguEmail).FirstOrDefault() == null)
                {
                    string encryptedPassword = MD5StringGenerator.GetMD5(register.CguPassword);
                    CGUnit cgunit = new CGUnit
                    {
                        Email = register.CguEmail,
                        FirstName = register.CguFirstName,
                        LastName = register.CguLastName,
                        Address = register.Address,
                        PhoneNo = register.PhoneNo,
                        UniversityID_FK = register.CguUniversityID,
                        Password = encryptedPassword,
                        Role = register.Role,
                    };
                    db.CGUnits.Add(cgunit);
                    db.SaveChanges();
                    return Json("Your account has been created! A System Admin will Approve it!", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("System Ran into an Error!", JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}