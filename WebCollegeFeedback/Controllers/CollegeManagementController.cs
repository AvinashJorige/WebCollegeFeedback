using DomainLayer;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using ServiceLayer.Interfaces;
using DomainLayer;
using System.Collections.Generic;

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
                        fname = colleges.CollegeName.Replace(" ", "_") + "_" + DateTime.Now.Ticks + "." + file.FileName.Split('.')[1];
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

        [HttpGet]
        [Route("CollegeList")]
        public JsonResult GetCollege()
        {
            return Json(new { data = collegesService.GetCollegesList() }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        [Route("FindCollege/{collegeId}/College")]
        public JsonResult GetCollege(string collegeId)
        {
            if (string.IsNullOrEmpty(collegeId))
            {
                return null;
            }

            List<CollegesModel> CollegeList = new List<CollegesModel>();
            CollegeList = (List<CollegesModel>)collegesService.GetCollegesList();

            CollegesModel collegesModel = CollegeList.Find(x => (x.CollgId).Trim().Equals(collegeId.Trim()));

            CollegeList.Clear();
            CollegeList = null;

            return Json(new { data = collegesModel }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCollegeDetails(CollegesModel model)
        {
            object obj = new { Code = 500, message = string.Empty };
            if (model != null)
            {
                HttpFileCollectionBase files = Request.Files;
                //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                //string filename = Path.GetFileName(Request.Files[i].FileName);  

                HttpPostedFileBase file = files[0];
                string fname;

                // Checking for Internet Explorer  
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = model.CollegeName.Replace(" ", "_") + "_" + DateTime.Now.Ticks + "." + file.FileName.Split('.')[1];
                }

                model.Image = "//Uploads//CollegeImages//" + fname;

                // Get the complete folder path and store the file inside it.  
                fname = Path.Combine(Server.MapPath("~/Uploads/CollegeImages/"), fname);
                file.SaveAs(fname);



                var data = collegesService.UpdateCollegeDetails(model);
                if(data != null)
                {
                    obj = new { Code = 200, message = "Updating the college is successful." };
                }
            }
            else
            {
                obj = new { Code = 501, message = "Sorry ! Something went wrong, update is not done." };
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult DeleteCollegeDetails(string CollegeId)
        {
            object obj = new { Code = 500, message = string.Empty };
            if (!string.IsNullOrEmpty(CollegeId))
            {
                var data = collegesService.DeleteCollegeDetails(CollegeId);
                if (data != null)
                {
                    obj = new { Code = 200, message = "College details are deleted successfully." };
                }
            }
            else
            {
                obj = new { Code = 501, message = "Sorry ! Something went wrong, update is not done." };
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}