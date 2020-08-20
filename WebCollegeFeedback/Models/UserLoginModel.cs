using System.ComponentModel.DataAnnotations;

namespace WebCollegeFeedback.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Please select the College")]
        [Display(Name = "College Name")]
        public string CollegeCode { get; set; }

        [Required(ErrorMessage = "Please Enter User Code")]
        [Display(Name = "User Code")]
        public string UserCode { get; set; }
        
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}