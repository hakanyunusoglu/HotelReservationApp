using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Data
{
    public class Admin : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}