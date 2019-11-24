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

        public static UserLoginViewModel UserParser(UserLogin user)
        {
            UserLoginViewModel userVM = new UserLoginViewModel();
            userVM.ValidationErrorMessage = user.ValidationErrorMessage;

            if (string.IsNullOrEmpty(user.ValidationErrorMessage))
            {
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
                bookVM.Authors = new List<AuthorViewModel>();
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
 
                foreach (var author in book.Authors)
                {
                    AuthorViewModel authorVM = new AuthorViewModel();
                    authorVM.AuthorId = author.AuthorId;
                    authorVM.Name = author.Name;
                    authorVM.Description = author.Description;

                    bookVM.Authors.Add(authorVM);
                }

                //bookVM.Author.AuthorId = book.Author.AuthorId;
                //bookVM.Author.Name = book.Author.Name;
                //bookVM.Author.Description = book.Author.Description;

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

        public static BookViewModel BooksDetailsParser(Book book)
        {
            BookViewModel bookVM = new BookViewModel();
            List<CopyViewModel> copiesVM = WebApiClient.GetAllCopies();

                bookVM.Authors = new List<AuthorViewModel>();
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
                bookVM.Edition = book.Edition;

                foreach (var author in book.Authors)
                {
                    AuthorViewModel authorVM = new AuthorViewModel();
                    authorVM.AuthorId = author.AuthorId;
                    authorVM.Name = author.Name;
                    authorVM.Description = author.Description;

                    bookVM.Authors.Add(authorVM);
                }

             
                bookVM.Publisher.PublisherId = book.Publisher.PublisherId;
                bookVM.Publisher.Name = book.Publisher.Name;
                bookVM.Publisher.Description = book.Publisher.Description;
                bookVM.Publisher.Address = book.Publisher.Address;

                bookVM.Category.CategoryId = book.Category.CategoryId;
                bookVM.Category.Name = book.Category.Name;
                bookVM.Category.Description = book.Category.Description;
                bookVM.ImagePath = book.ImagePath;
                bookVM.Copies = copiesVM.Where(x => x.Book.BookId == book.BookId).ToList();

            return bookVM;

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
                copyVM.Location.ShelfRow = copy.Location.ShelfRow;
                copyVM.Location.ShelfCol = copy.Location.ShelfCol;
                copyVM.Book.BookId = copy.Book.BookId;
                copyVM.Book.ImagePath = copy.Book.ImagePath;
                copyList.Add(copyVM);
            }

            return copyList;

        }

        public static List<CommentViewModel> CommentParser(List<Comment> comments)
        {
            List<CommentViewModel> commentList = new List<CommentViewModel>();
            foreach (var comment in comments)
            {
                CommentViewModel commentVM = new CommentViewModel();
                commentVM.Commenter = new UserLoginViewModel();
                commentVM.Book = new BookViewModel();

                commentVM.CommentId = comment.CommentId;
                commentVM.Content = comment.Content;
                commentVM.Rating = comment.Rating;
                commentVM.Date = comment.Date;

                commentVM.Commenter.UserLoginId = comment.Commenter.UserLoginId;
                commentVM.Commenter.Email = comment.Commenter.Email;
                commentVM.Commenter.FullName = comment.Commenter.FullName;
                commentVM.Commenter.IsActive = comment.Commenter.IsActive;
                commentVM.Commenter.PhoneNumber = comment.Commenter.PhoneNumber;
                commentVM.Commenter.RFID = comment.Commenter.RFID;
                commentVM.Commenter.UserName = comment.Commenter.UserName;
             
                commentList.Add(commentVM);
            }

            return commentList;

        }

        public static List<ReviewViewModel> ReviewParser(List<Review> reviews)
        {
            List<ReviewViewModel> reviewList = new List<ReviewViewModel>();
            foreach (var review in reviews)
            {
                ReviewViewModel reviewVM = new ReviewViewModel();
                
                reviewVM.ReviewId = review.ReviewId;
                reviewVM.Content = review.Content;
                reviewVM.Reviewer = review.Reviewer;

                reviewList.Add(reviewVM);
            }

            return reviewList;

        }


    }
}