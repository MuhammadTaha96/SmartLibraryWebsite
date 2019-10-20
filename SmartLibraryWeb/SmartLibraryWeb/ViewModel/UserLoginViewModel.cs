﻿using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class UserLoginViewModel
    {
        public int UserLoginId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage="Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        
        public string RFID { get; set; }
        public bool IsActive { get; set; }

        public string UserTypeName { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}