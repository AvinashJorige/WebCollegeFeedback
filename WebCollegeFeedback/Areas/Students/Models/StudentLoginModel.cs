using System.ComponentModel.DataAnnotations;

namespace WebCollegeFeedback.Areas.Students.Models
{
    public class StudentLoginModel
    {
        [Required(ErrorMessage = "Please select the College")]
        [Display(Name = "College Name")]
        public string CollegeCode { get; set; }

        [Required(ErrorMessage = "Please Enter User Code")]
        [Display(Name = "User Code")]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}