using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public int Shelf { get; set; }
        public int ShelfRow { get; set; }
        public int ShelfCol { get; set; }
    }
}