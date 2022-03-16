using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.DTO.Room
{
    public class RoomOperations
    {

        HotelReservationNew.Models.Context.HotelReservationNewDBContext db = new Context.HotelReservationNewDBContext();
        public int GetRoomCount ()
        {
            int count = db.Rooms.Count();
            return count;
        }

    }
}