using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class ElectronicFileViewModel
    {
        public int ElectronicFileId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public ElectronicFileTypeViewModel FileType { get; set; }
    }
}