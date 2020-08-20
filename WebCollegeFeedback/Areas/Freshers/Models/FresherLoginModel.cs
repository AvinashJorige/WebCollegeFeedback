using System.ComponentModel.DataAnnotations;

namespace WebCollegeFeedback.Areas.Freshers.Models
{
    public class FresherLoginModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User Code")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}