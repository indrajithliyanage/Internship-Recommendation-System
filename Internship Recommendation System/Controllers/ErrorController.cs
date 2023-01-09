using System.Web.Mvc;

namespace Internship_Recommendation_System.Controllers
{
    public class ErrorController : Controller
    {
        // GET: NotFound
        [AllowAnonymous]
        [HttpGet]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}