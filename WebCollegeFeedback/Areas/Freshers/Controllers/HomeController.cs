using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCollegeFeedback.Areas.Freshers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Freshers/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        [Route("Profile")]
        public ActionResult FresherProfile()
        {
            return View();
        }

        [HttpGet]
        [Route("Colleges")]
        public ActionResult FresherColleges()
        {
            return View();
        }

        [HttpGet]
        [Route("Feedback")]
        public ActionResult FresherFeedback()
        {
            return View();
        }
    }
}