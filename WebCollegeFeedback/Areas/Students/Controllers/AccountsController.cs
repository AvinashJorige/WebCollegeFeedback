using DomainLayer;
using ServiceLayer;
using ServiceLayer.Interfaces;
using System.Web.Mvc;
using System.Web.Security;
using WebCollegeFeedback.Areas.Students.Models;

namespace WebCollegeFeedback.Areas.Students.Controllers
{
    public class AccountsController : Controller
    {
        private IStudentService _studentService;
        public AccountsController()
        {
            _studentService = new StudentService();
        }

        // GET: Students/Accounts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(StudentLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                StudentModel IsValid = _studentService.ValidateUser(loginModel.CollegeCode, loginModel.UserCode, loginModel.Password);
                if (IsValid != null)
                {
                    FormsAuthentication.SetAuthCookie(IsValid.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
            else
            {
                return View(loginModel);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}