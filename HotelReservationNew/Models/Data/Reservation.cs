using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Data
{
    public class Reservation : BaseEntity
    {

        public int UserID { get; set; }

        public int RoomID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ReserveDateBegin { get; set; }
        public DateTime ReserveDateEnd { get; set; }


        public double Cost { get; set; }

        public virtual User User { get; set; }
        public virtual Room Room { get; set; }


    }
}