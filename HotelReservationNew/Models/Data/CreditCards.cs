using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Data
{
    public class CreditCards : BaseEntity
    {
        public int UserID { get; set; }

        public string Number { get; set; }
        public string HolderName { get; set; }
        public string Validate { get; set; }
        public virtual User User { get; set; }
    }
}