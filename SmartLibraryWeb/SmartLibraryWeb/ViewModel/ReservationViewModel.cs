using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLibraryWeb.ViewModel
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsCancled { get; set; }

        public CopyViewModel ReservedCopy { get; set; }
        public UserLoginViewModel ReservedBy { get; set; }
        public ReservationStatusViewModel Status { get; set; }
    }
}