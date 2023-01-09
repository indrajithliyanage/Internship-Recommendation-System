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
    public class HomeController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                CurrentUserViewModel currentUser = JsonConvert.DeserializeObject<CurrentUserViewModel>(authTicket.UserData);
                if (currentUser.Role != null)
                {
                    switch (currentUser.Role)
                    {
                        case "ADM":
                            ViewBag.Role = "Admin";
                            break;
                        case "CGU":
                            ViewBag.Role = "Manager";
                            break;
                        case "STU":
                            ViewBag.Role = "User";
                            break;
                        default:
                            ViewBag.Role = "User";
                            break;
                    }
                };
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult About()
        {            
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Contact()
        {            
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult UserProfile()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                // Get the forms authentication ticket.
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                CurrentUserViewModel currentUser = JsonConvert.DeserializeObject<CurrentUserViewModel>(authTicket.UserData);
                ViewBag.Name = currentUser.FirstName + " " + currentUser.LastName;
                if (currentUser.Role != null)
                {
                    switch (currentUser.Role)
                    {
                        case "ADM":
                            ViewBag.Role = "Admin";
                            ViewBag.Name = "Administrator";
                            break;
                        case "CGU":
                            ViewBag.Role = "Manager";
                            break;
                        case "STU":
                            ViewBag.Role = "User";
                            break;
                        default:
                            ViewBag.Role = "User";
                            break;
                    }
                };
                ViewBag.Email = currentUser.Email;
            }
            else
            {
                return RedirectToAction("Login","Auth");
            }
                return View();
        }
    }
}