using Models;
using SmartLibraryWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.Operations
{
    public class Parser
    {
        public static UserLoginViewModel UserLoginParser(UserLogin user)
        {
            UserLoginViewModel userVM = null;

            if (user != null)
            {
                userVM = new UserLoginViewModel();

                userVM.Email = user.Email;
                userVM.IsActive = user.IsActive;
                userVM.FullName = user.FullName;
                userVM.Password = user.Password;
                userVM.PhoneNumber = user.PhoneNumber;
                userVM.UserLoginId = user.UserLoginId;
                userVM.UserName = user.UserName;
                userVM.UserTypeName = user.UserType.Name;
                userVM.UserTypeId = user.UserType.UserTypeId;
            }
            return userVM;
        }

        public static List<BookViewModel> BooksParser(List<Book> books)
        {
            List<BookViewModel> booksVM = new List<BookViewModel>();
            List<CopyViewModel> copiesVM = WebApiClient.GetAllCopies();

            foreach (var book in books)
            {
                BookViewModel bookVM = new BookViewModel();
                bookVM.Author = new AuthorViewModel();
                bookVM.Publisher = new PublisherViewModel();
                bookVM.Category = new CategoryViewModel();
                bookVM.Copies = new List<CopyViewModel>();

                bookVM.BookId = book.BookId;
                bookVM.Title = book.Title;
                bookVM.Description = book.Description;
                bookVM.IsAvailable = book.IsAvailable;
                bookVM.Language = book.Language;
                bookVM.ISBN_No = book.ISBN_No;
                bookVM.IsDeleted = book.IsDeleted;
                bookVM.PublishedYear = book.PublishedYear;

                bookVM.Author.AuthorId = book.Author.AuthorId;
                bookVM.Author.Name = book.Author.Name;
                bookVM.Author.Description = book.Author.Description;

                bookVM.Publisher.PublisherId = book.Publisher.PublisherId;
                bookVM.Publisher.Name = book.Publisher.Name;
                bookVM.Publisher.Description = book.Publisher.Description;

                bookVM.Category.CategoryId = book.Category.CategoryId;
                bookVM.Category.Name = book.Category.Name;
                bookVM.Category.Description = book.Category.Description;
                bookVM.ImagePath = book.ImagePath;
                bookVM.Copies = copiesVM.Where(x => x.Book.BookId == book.BookId).ToList();

                booksVM.Add(bookVM);
            }

            return booksVM;

        }

        public static List<CopyViewModel> CopiesParser(List<Copy> copies)
        {
            List<CopyViewModel> copyList = new List<CopyViewModel>();
            foreach (var copy in copies)
            {
                CopyViewModel copyVM = new CopyViewModel();
                copyVM.Status = new StatusViewModel();
                copyVM.Location = new LocationViewModel();
                copyVM.Book = new BookViewModel();

                copyVM.CopyId = copy.CopyId;
                copyVM.RFID = copy.RFID;
                copyVM.Status.StatusId = copy.Status.StatusId;
                copyVM.Status.Name = copy.Status.Name;
                copyVM.Location.LocationId = copy.Location.LocationId;
                copyVM.Location.Shelf = copy.Location.Shelf;
                copyVM.Location.ShelfLine = copy.Location.ShelfLine;
                copyVM.Book.BookId = copy.Book.BookId;

                copyList.Add(copyVM);
            }

            return copyList;

        }


    }
}