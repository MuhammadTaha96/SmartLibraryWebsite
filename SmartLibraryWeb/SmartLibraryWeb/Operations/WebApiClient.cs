using Models;
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

        public static bool ReserveACopy(int bookId, int userLoginId)
        {
            string urlWebConfig = ConfigurationManager.AppSettings["ApiURL"].ToString();
            string controller = "values";
            string action = "ReserveACopy";
            bool success = false;
            string html = string.Empty;
           
            string url = urlWebConfig + "/" + controller + "/" + action + "?bookId=" + bookId + "&userLoginId=" + userLoginId;

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
    }
}