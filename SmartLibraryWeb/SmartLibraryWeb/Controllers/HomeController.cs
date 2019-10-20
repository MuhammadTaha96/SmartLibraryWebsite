using SmartLibraryWeb.Operations;
using SmartLibraryWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartLibraryWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserModel"] == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetAllBooks()
        {
            if (Session["UserModel"] == null)
                return RedirectToAction("Login", "Account");

            List<BookViewModel> bookList = new List<BookViewModel>();
            bookList = WebApiClient.GetAllBooks();

            Session["BookList"] = bookList;

            return View(bookList);
        }

   
        public ActionResult BookDetails(int id)
        {
            if (Session["UserModel"] == null)
                return RedirectToAction("Login", "Account");

            List<BookViewModel> bookList = Session["BookList"] as List<BookViewModel>;
            BookViewModel bookVM = bookList.Where(x => x.BookId == id).SingleOrDefault();
            return View(bookVM);
        }

        public ActionResult Reserve(int bookId)
        {
            UserLoginViewModel userLogin = Session["UserModel"] as UserLoginViewModel;
            List<BookViewModel> bookList = Session["BookList"] as List<BookViewModel>;
            bool reserved = WebApiClient.ReserveACopy(bookId, userLogin.UserLoginId);
            BookViewModel book = WebApiClient.GetAllBooks().Where(x => x.BookId == bookId).SingleOrDefault();
            ViewData["resMessage"] = reserved ? "Your book has been reserved" : "An Error Occured";
            ViewData["reserved"] = reserved; 
            return View("BookDetails", book);
        }

    }
}