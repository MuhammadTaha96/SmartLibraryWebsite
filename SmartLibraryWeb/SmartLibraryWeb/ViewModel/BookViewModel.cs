using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
        public string ISBN_No { get; set; }
        public string ImagePath { get; set; }
        public string Edition { get; set; }

        public PublisherViewModel Publisher { get; set; }
        public CategoryViewModel Category { get; set; }

        public List<AuthorViewModel> Authors { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<CopyViewModel> Copies { get; set; }
        public List<ReservationViewModel> Reservations { get; set; }
    }
}