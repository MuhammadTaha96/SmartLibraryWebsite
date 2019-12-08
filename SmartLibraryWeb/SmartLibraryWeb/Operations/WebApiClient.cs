﻿using Models;
using Newtonsoft.Json;
using SmartLibraryWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SmartLibraryWeb.Operations
{
    public class WebApiClient
    {
        
            
        public static UserLoginViewModel ValidateUser(string username, string password)
        {
            UserLoginViewModel userVM = new UserLoginViewModel();
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "ValidateUser";
            bool valid = false;
            string html = string.Empty;
            UserLogin user = null;

            string url = urlWebConfig + "/" + controller + "/" + action + "?username=" + username + "&password=" +password ;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
               user = JsonConvert.DeserializeObject<UserLogin>(html);
            }

            userVM = Parser.UserLoginParser(user);

            return userVM;
        }

        public static UserLoginViewModel ValidateUserLogin(string username, string password)
        {
            UserLoginViewModel userVM = new UserLoginViewModel();
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "ValidateUserLogin";
            bool valid = false;
            string html = string.Empty;
            UserLogin user = null;

            string url = urlWebConfig + "/" + controller + "/" + action + "?username=" + username + "&password=" + password;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                user = JsonConvert.DeserializeObject<UserLogin>(html);
            }

            userVM = Parser.UserParser(user);

            return userVM;
        }

        public static bool ChangePassword(string username, string password)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "ChangePassword";
            bool success = false;
            string html = string.Empty;
            UserLogin user = null;

            string url = urlWebConfig + "/" + controller + "/" + action + "?username=" + username + "&password=" + password;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                success = bool.Parse(html);
            }

            return success;
        }

        public static List<BookViewModel> GetAllBooks()
        {
            List<BookViewModel> bookVM = new List<BookViewModel>();
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetAllBooks";
            bool valid = false;
            string html = string.Empty;
            List<Book> books = null;
           
            string url = urlWebConfig + "/" + controller + "/" + action;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(html);
            }

            return Parser.BooksParser(books);
        }

        public static BookViewModel GetBookDetails(int bookId)
        {
            List<BookViewModel> bookVM = new List<BookViewModel>();
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetBookDetails";
            bool valid = false;
            string html = string.Empty;
            Book book = null;

            string url = urlWebConfig + "/" + controller + "/" + action + "?bookId=" + bookId;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                book = JsonConvert.DeserializeObject<Book>(html);
            }

            return Parser.BooksDetailsParser(book);
        }

        public static List<CopyViewModel> GetAllCopies()
        {
            List<CopyViewModel> bookVM = new List<CopyViewModel>();
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetCopies";
            bool valid = false;
            string html = string.Empty;
            List<Copy> copies = null;

            string url = urlWebConfig + "/" + controller + "/" + action;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                copies = JsonConvert.DeserializeObject<List<Copy>>(html);
            }

            return Parser.CopiesParser(copies);
        }

        public static ReservationViewModel ReserveACopy(int bookId, int userLoginId)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "ReserveACopy";
            string html = string.Empty;
            Reservation reservation = null;

            string url = urlWebConfig + "/" + controller + "/" + action + "?bookId=" + bookId + "&userLoginId=" + userLoginId;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                reservation = JsonConvert.DeserializeObject<Reservation>(html);
            }

            return Parser.ReservationParser(reservation);
        }

        public static List<CommentViewModel> GetComments(string bookId)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetComments";
            bool success = false;
            string html = string.Empty;

            string url = urlWebConfig + "/" + controller + "/" + action + "?bookId=" + bookId;
            List<Comment> comments = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                comments = JsonConvert.DeserializeObject<List<Comment>>(html);
            }

            return Parser.CommentParser(comments);
        }

        public static List<ReservationViewModel> GetActiveReservationsByUser(int userLoginId)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetActiveReservationsByUser";
            bool success = false;
            string html = string.Empty;

            string url = urlWebConfig + "/" + controller + "/" + action + "?userLoginId=" + userLoginId;
            List<Reservation> reservationList = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                reservationList = JsonConvert.DeserializeObject<List<Reservation>>(html);
            }

            return Parser.ReservationListParser(reservationList);
        }

        public static List<ReviewViewModel> GetReviews(string bookId)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetReviews";
            bool success = false;
            string html = string.Empty;

            string url = urlWebConfig + "/" + controller + "/" + action + "?bookId=" + bookId;
            List<Review> reviews = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                reviews = JsonConvert.DeserializeObject<List<Review>>(html);
            }

            return Parser.ReviewParser(reviews);
        }

        public static bool AddComment(string bookId, string commentText, string userLoginId)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "AddComment";
            bool success = false;
            string html = string.Empty;
            

            string url = urlWebConfig + "/" + controller + "/" + action + "?bookId=" + int.Parse(bookId) + "&commentText=" + commentText + "&userLoginId=" + int.Parse(userLoginId);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                success = bool.Parse(html);
            }

            return success;
        }

        //Getting location of all available copies by bookId
        public static List<CopyViewModel> GetAvailableCopies(int bookId)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetAvailableCopies";
            string html = string.Empty;
            List<Copy> copies = null;
            List<CopyViewModel> copiesVM = null;

            string url = urlWebConfig + "/" + controller + "/" + action + "?bookId=" + bookId;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                copies = JsonConvert.DeserializeObject<List<Copy>>(html);
            }

            copiesVM = Parser.CopiesParser(copies);
            return copiesVM;
        }

        public static List<ElectronicFileViewModel> GetEletronicFiles(int fileType)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "GetEletronicFiles";
            string html = string.Empty;
            List<ElectronicFile> efiles = null;
            List<ElectronicFileViewModel> efilesVM = null;

            string url = urlWebConfig + "/" + controller + "/" + action + "?fileType=" + fileType;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                efiles = JsonConvert.DeserializeObject<List<ElectronicFile>>(html);
            }

            efilesVM = Parser.ElectronicFileParser(efiles);
            return efilesVM;
        }
    }
}