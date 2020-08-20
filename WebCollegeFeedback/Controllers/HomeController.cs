using ServiceLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;


namespace WebCollegeFeedback.Controllers
{
    public class HomeController : Controller
    {
        private IAdminService _adminService;

        public HomeController()
        {
            _adminService = AdminMasterService.GetInstance;
        }
        public ActionResult Index()
        {
            var list = _adminService.GetAdminUsers();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}