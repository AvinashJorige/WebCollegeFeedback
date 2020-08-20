using DomainLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebCollegeFeedback.Models
{
    public class RegistrationModel
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

        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Re-Enter Password")]
        [Display(Name = "Confirm Password")]
        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Please Enter EMail")]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter DOB")]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Number")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please upload Image")]
        [Display(Name = "Image")]
        public string Image { get; set; }
        
        public IEnumerable<CollegesModel> CollegesList { get; set; }
    }
}