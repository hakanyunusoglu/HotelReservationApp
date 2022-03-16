using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.ViewModels
{
    public class SearchViewModel
    { 
        public double Price { get; set; }
        public bool Availability { get; set; } 
     
        public int Floor { get; set; }
        public string RoomType { get; set; }

        public int MaxAdult { get; set; }
        public int MaxChild { get; set; }
 



    }
}