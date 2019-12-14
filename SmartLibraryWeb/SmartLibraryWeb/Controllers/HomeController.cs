using Newtonsoft.Json;
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

            return View(bookList);
        }

        public ActionResult GetElectronicFiles(int fileTypeId)
        {
            if (Session["UserModel"] == null)
                return RedirectToAction("Login", "Account");

            List<ElectronicFileViewModel> EFVM = WebApiClient.GetEletronicFiles(fileTypeId);
            Session["ElectronicFiles"] = EFVM;

            return View(EFVM);
        }

        public FileResult DownloadFile(string fileName)
        {
            List<ElectronicFileViewModel> EFVMlist = Session["ElectronicFiles"] as List<ElectronicFileViewModel>;

            ElectronicFileViewModel EFVM = EFVMlist.Where(x => x.FileName.Equals(fileName)).SingleOrDefault();

            return File(EFVM.Path, "pdf", EFVM.FileName + ".pdf");
        }



        [HttpPost]
        public ActionResult GetBookJsonResponse()
        {
            if (Session["UserModel"] == null)
                return RedirectToAction("Login", "Account");

            List<BookViewModel> bookList = new List<BookViewModel>();
            bookList = WebApiClient.GetAllBooks();
            Session["BookList"] = bookList;

            string json = JsonConvert.SerializeObject(bookList);


            return Content(json);
        }



        public ActionResult BookDetails(int id)
        {
            if (Session["UserModel"] == null)
                return RedirectToAction("Login", "Account");

            BookViewModel bookVM = WebApiClient.GetBookDetails(id);
            return View(bookVM);
        }

        [HttpGet]
        public ActionResult ReserveACopy(int bookId)
        {
            UserLoginViewModel userLogin = Session["UserModel"] as UserLoginViewModel;
            List<BookViewModel> bookList = Session["BookList"] as List<BookViewModel>;
            ReservationViewModel reservationVM = WebApiClient.ReserveACopy(bookId, userLogin.UserLoginId);
            BookViewModel book = WebApiClient.GetAllBooks().Where(x => x.BookId == bookId).SingleOrDefault();
            //ViewData["resMessage"] = reserved ? "Your book has been reserved" : "";
            //ViewData["reserved"] = reserved;
            //Session["ReservationViewModel"] = reservationVM;

            return RedirectToAction("Report");
        }

        [HttpGet]
        public ActionResult ReserveACopy2(int bookId)
        {
            UserLoginViewModel userLogin = Session["UserModel"] as UserLoginViewModel;
            List<BookViewModel> bookList = Session["BookList"] as List<BookViewModel>;
            ReservationViewModel reservationVM = WebApiClient.ReserveACopy(bookId, userLogin.UserLoginId);
            BookViewModel book = WebApiClient.GetAllBooks().Where(x => x.BookId == bookId).SingleOrDefault();
            //ViewData["resMessage"] = reserved ? "Your book has been reserved" : "";
            //ViewData["reserved"] = reserved;
            //Session["ReservationViewModel"] = reservationVM;

            return RedirectToAction("Report");
        }

        //This method just redirects the ReservedACopy2 method to reserve the copy
        public ActionResult ReservationReport()
        {
            int bookId = int.Parse(Session["ReservedBookSession"].ToString());
            return RedirectToAction("ReserveACopy2", new { bookId = bookId });
        }

        //Report is called either directly by student/faculty or it is opened after each reservation
        public ActionResult Report()
        {
            UserLoginViewModel userLogin = Session["UserModel"] as UserLoginViewModel;
            List<ReservationViewModel> reservation = WebApiClient.GetActiveReservationsByUser(userLogin.UserLoginId);

            return View("ReservationReport", reservation);
        }

        [HttpPost]
        public virtual PartialViewResult CommentsPartialView(string bookId)
        {

            List<CommentViewModel> commentVMList = WebApiClient.GetComments(bookId);


            return PartialView(commentVMList);
        }

        [HttpPost]
        public virtual PartialViewResult ReviewsPartialView(string bookId)
        {

            List<ReviewViewModel> reviewVMList = WebApiClient.GetReviews(bookId);


            return PartialView(reviewVMList);
        }

        [HttpPost]
        public virtual ActionResult AddComment(string bookId, string commentText, string userLoginId)
        {
            bool success = WebApiClient.AddComment(bookId, commentText, userLoginId);

            return Json(new { success = success });
        }

        [HttpPost]
        public virtual PartialViewResult BookLocationPartialView(int bookId)
        {
            List<CopyViewModel> commentVMList = WebApiClient.GetAvailableCopies(bookId);
            return PartialView(commentVMList);
        }
    }
}