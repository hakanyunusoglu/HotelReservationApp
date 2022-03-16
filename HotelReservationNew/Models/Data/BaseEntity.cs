using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationNew.Models.Data
{
    public class BaseEntity
    {
        public int ID { get; set; }

        DateTime _addDate = DateTime.Now;
        public DateTime AddDate
        {
            get { return _addDate; }

            set { _addDate = value; }

        }


        private bool _IsDelete = false;
        public bool IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }
        DateTime _UpdatedDate = DateTime.Now;
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }

            set { _UpdatedDate = value; }

        }


    }
}