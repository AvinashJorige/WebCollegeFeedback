using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCollegeFeedback.Controllers
{
    [RoutePrefix("Colleges")]
    public class CollegeManagementController : Controller
    {
        [Route("AddCollege")]
        // GET: CollegeManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}