using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCollegeFeedback.Areas.Students.Controllers
{
    public class HomeController : Controller
    {
        // GET: Students/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("Profile")]
        public ActionResult StudentProfile()
        {
            return View();
        }
        
        [HttpGet]
        [Route("Colleges")]
        public ActionResult StudentColleges()
        {
            return View();
        }

        [HttpGet]
        [Route("Placements")]
        public ActionResult StudentPlacements()
        {
            return View();
        }

        [HttpGet]
        [Route("Feedback")]
        public ActionResult StudentFeedback()
        {
            return View();
        }
    }
}