using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class CopyViewModel
    {
        public int CopyId { get; set; }
        public string RFID { get; set; }
        public StatusViewModel Status { get; set; }
        public BookViewModel Book { get; set; }
        public LocationViewModel Location { get; set; }
    }
}