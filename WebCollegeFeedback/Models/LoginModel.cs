using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCollegeFeedback.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User Code")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}