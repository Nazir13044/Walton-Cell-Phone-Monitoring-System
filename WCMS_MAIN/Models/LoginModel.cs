using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WCMS_MAIN.Models
{
    public class LoginModel
    {

        public long UserId { get; set; }
        [Required(ErrorMessage = "Please enter the User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public long? UserRoleId { get; set; }
        public int? UserLineId { get; set; }
        public int? PackLineId { get; set; }
        public string RoleName { get; set; }
        public string EmployeeName { get; set; }
        public Boolean Remember { get; set; }

    }
}