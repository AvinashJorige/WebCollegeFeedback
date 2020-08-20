using DomainLayer;
using ServiceLayer;
using ServiceLayer.Interfaces;
using System.Web.Mvc;
using System.Web.Security;
using WebCollegeFeedback.Models;

namespace WebCollegeFeedback.Areas.Students.Controllers
{
    public class AccountsController : Controller
    {
        private IStudentService _studentService;
        private ICollegesService _collegesService;

        public AccountsController()
        {
            _studentService = new StudentService();
            _collegesService = new CollegesService();
        }

        // GET: Students/Accounts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            RegistrationModel registration  = new RegistrationModel();
            registration.CollegesList = _collegesService.GetCollegesList();


            return View(registration);
        }

        [HttpPost]
        public ActionResult Login(RegistrationModel loginModel)
        {
            if (ModelState.IsValid)
            {
                StudentModel IsValid = _studentService.ValidateUser(clgCode: loginModel.CollegeCode, userid: loginModel.UserCode, password: loginModel.Password);
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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            bool bRegisted = false;
            if (ModelState.IsValid)
            {
                if (model != null && !string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
                {

                    StudentModel _stdModel = new StudentModel();

                    _stdModel.Image         = model.Image;
                    _stdModel.Password      = model.Password;
                    _stdModel.UserName      = model.UserName;
                    _stdModel.Address       = model.Address;
                    _stdModel.CollegeCode   = model.CollegeCode;
                    _stdModel.ContactNo     = model.ContactNo;
                    _stdModel.DOB           = model.DOB;
                    _stdModel.Email         = model.Email;

                    bRegisted = _studentService.RegisterStudent(_stdModel);
                    if (!bRegisted)
                    {
                        ModelState.AddModelError("", "Registration is not completed. Please contact to your Admin.");
                        return View();
                    }
                    else
                    {
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid Username or Password. Please fill proper details.");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}