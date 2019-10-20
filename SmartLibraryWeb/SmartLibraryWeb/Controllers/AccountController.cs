using SmartLibraryWeb.Operations;
using SmartLibraryWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartLibraryWeb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel user)
        {
            UserLoginViewModel userLogin = WebApiClient.ValidateUser(user.UserName, user.Password);
            if (userLogin != null)
            {
                Session["UserModel"] = userLogin;
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["LoginFailureMessage"] = "Username or Password are incorrect";
            }

            return View();
        }

        public ActionResult Signout()
        {
            Session["UserModel"] = null;
            Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            UserLoginViewModel user = Session["UserModel"] as UserLoginViewModel;

            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.UserName = user.UserName;
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            bool passChanged = false;

            UserLoginViewModel user = Session["UserModel"] as UserLoginViewModel;

            if (WebApiClient.ValidateUser(user.UserName, model.OldPassword) != null)
            {
                passChanged = WebApiClient.ChangePassword(user.UserName, model.NewPassword);
               ViewData["PassChangeMessage"] = passChanged ? "Your Password has been changed successfully!" : "Something Went wrong. Please try again later";
               ViewData["PasswordChanged"] = passChanged;
            }
            else
            {
                ViewData["PassChangeMessage"] = "Please enter correct old password";
            }


            return View(model);
        }

    }
}