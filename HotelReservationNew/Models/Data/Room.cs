using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Data
{
    public class Room : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Availability { get; set; }
        public string CoverImage { get; set; }
        public string Bed { get; set; }
        public int Floor { get; set; }
        public string RoomType { get; set; }

        public int MaxAdult { get; set; }

        public int MaxChild { get; set; }

        public int Counter { get; set; }
    }
}