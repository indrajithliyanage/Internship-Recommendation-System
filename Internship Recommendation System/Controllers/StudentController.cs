using Internship_Recommendation_System.Models;
using Internship_Recommendation_System.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Internship_Recommendation_System.Controllers
{
    public class StudentController : Controller
    {
        // GET: View Student
        [Authorize]
        [HttpGet]
        public ActionResult ViewStudents()
        {
            List<StudentViewModel> newStudentList = new List<StudentViewModel>();
            using (IRSEntities db = new IRSEntities())
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    // Get the forms authentication ticket.
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    CurrentUserViewModel currentUser = JsonConvert.DeserializeObject<CurrentUserViewModel>(authTicket.UserData);
                    var studentList = db.Students.Include(e => e.Degree).Where(e => e.UniversityID_FK == currentUser.UniversityID).ToList();
                    foreach (var student in studentList)
                    {
                        StudentViewModel newStudent = new StudentViewModel();
                        newStudent.UserID = student.StudentID;
                        newStudent.FirstName = student.FirstName;
                        newStudent.LastName = student.LastName;
                        newStudent.Gender = student.Gender;
                        newStudent.DateofBirth = student.DateOfBirth;
                        newStudent.DegreeID = student.DegreeID_FK;
                        newStudent.Email = student.Email;
                        newStudent.IndexNo = student.IndexNo;
                        newStudent.IsApproved = student.IsApproved;
                        newStudent.DegreeName = student.Degree.DegreeName;
                        newStudentList.Add(newStudent);
                    }
                }
                else
                {
                    return RedirectToAction("Login","Auth");
                }
            }
            return View(newStudentList);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ApproveStudent(int? id)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (IRSEntities db = new IRSEntities())
                {
                    Student student = db.Students.Find(id);
                    if (student == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        student.IsApproved = true;
                        db.Entry(student).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { redirectToUrl = Url.Action("ViewStudents", "Student") });
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (IRSEntities db = new IRSEntities())
            {
                Student student = db.Students.Find(id);
                if (student == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
            }
            return Json(new { redirectToUrl = Url.Action("ViewStudents", "Student") });
        }
    }
}