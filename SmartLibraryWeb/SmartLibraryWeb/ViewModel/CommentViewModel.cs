using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public UserLoginViewModel Commenter { get; set; }
        public BookViewModel Book { get; set; }
        public DateTime Date { get; set; }
    }
}