using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<HotelReservationNew.Models.Data.User> Users { get; set; }
        public IEnumerable<HotelReservationNew.Models.Data.Room> Rooms { get; set; }

        public IEnumerable<HotelReservationNew.Models.Data.CreditCards> CreditCards { get; set; }

        public IEnumerable<HotelReservationNew.Models.Data.RoomPicture> RoomPictures { get; set; }

        public IEnumerable<HotelReservationNew.Models.Data.Reservation> Reservations { get; set; }

        HotelReservationNew.Models.Context.HotelReservationNewDBContext db = new Context.HotelReservationNewDBContext();
        public int GetRoomCount()
        {
            int count = db.Rooms.Count();
            return count;
        }

    }
}