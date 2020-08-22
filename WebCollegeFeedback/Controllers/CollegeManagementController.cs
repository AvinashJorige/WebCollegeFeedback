using DomainLayer;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;
using DomainLayer;

namespace WebCollegeFeedback.Controllers
{
    [RoutePrefix("Colleges")]
    public class CollegeManagementController : Controller
    {
        private ICollegesService collegesService;
        public CollegeManagementController()
        {
            collegesService = new CollegesService();
        }

        [Route("AddCollege")]
        // GET: CollegeManagement
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCollegeDetails(CollegesModel colleges)
        {
            // Checking no of files injected in Request object  
            try
            {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    colleges.Image = "//Uploads//CollegeImages//" + fname;

                    // Get the complete folder path and store the file inside it.  
                    fname = Path.Combine(Server.MapPath("~/Uploads/CollegeImages/"), fname);
                    file.SaveAs(fname);
                    colleges.CreatedDate = DateTime.Now;
                    colleges.IsActive = true;

                    collegesService.SaveCollegeDetails(colleges);
                }
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
            // Returns message that successfully uploaded  
            return Json("New College details are added successfully.");
        }
    }
}