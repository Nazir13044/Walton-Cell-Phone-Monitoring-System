using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WCMS_MAIN.Models
{
    public class EmployeeInfo
    {
        [Required]
        [Display(Name = " Name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = " Country")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Country { get; set; }
    }
}