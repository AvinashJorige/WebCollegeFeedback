using DomainLayer;
using ServiceLayer;
using ServiceLayer.Interfaces;
using System.Web.Mvc;
using System.Web.Security;
using WebCollegeFeedback.Areas.Freshers.Models;

namespace WebCollegeFeedback.Areas.Freshers.Controllers
{
    public class AccountsController : Controller
    {
        private IFreshersService _freshersService;
        public AccountsController()
        {
            _freshersService = new FreshersService();
        }

        // GET: Freshers/Accounts
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
        public ActionResult Login(FresherLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                FreshersModel freshersModel = _freshersService.ValidateUser(loginModel.UserName, loginModel.Password);
                if (freshersModel != null)
                {
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, false);
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
    }
}