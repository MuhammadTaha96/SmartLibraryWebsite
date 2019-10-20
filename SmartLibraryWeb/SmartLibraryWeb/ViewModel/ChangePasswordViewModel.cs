using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage="Old Password is required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
    }
}