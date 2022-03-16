using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Areas.Yonetim.Models.ManagementView
{
    public class ManageView
    {
        public IEnumerable<HotelReservationNew.Models.Data.Reservation> Reservations { get; set; }
        public IEnumerable<HotelReservationNew.Models.Data.User> Users { get; set; }
        public IEnumerable<HotelReservationNew.Models.Data.Room> Rooms { get; set; }
        public IEnumerable<HotelReservationNew.Models.Data.Contact> Contacts { get; set; }

    }
}