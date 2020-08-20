using DomainLayer;
using ServiceLayer;
using ServiceLayer.Interfaces;
using System.Web.Mvc;
using System.Web.Security;
using WebCollegeFeedback.Models;

namespace WebCollegeFeedback.Controllers
{
    public class AccountController : Controller
    {
        private IAdminService _adminService;
        public AccountController()
        {
            _adminService = AdminMasterService.GetInstance;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AdminModel IsValidAdmin = _adminService.ValidateUser(model.UserName, model.Password);
                if (IsValidAdmin != null)
                {
                    FormsAuthentication.SetAuthCookie(IsValidAdmin.Name, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}