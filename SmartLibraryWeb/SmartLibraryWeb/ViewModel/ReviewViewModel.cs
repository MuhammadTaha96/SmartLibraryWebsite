using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class ReviewViewModel
    {
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public string Reviewer { get; set; }
        //public BookViewModel Book { get; set; }
    }
}