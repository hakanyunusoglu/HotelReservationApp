using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Data
{
    public class RoomPicture : BaseEntity
    {
        public string Url { get; set; }
        public int RoomID { get; set; }

        public virtual Room Room{ get; set; }

    }
}