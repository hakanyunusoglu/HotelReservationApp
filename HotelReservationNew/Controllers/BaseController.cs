using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelReservationNew.Models;
namespace HotelReservationNew.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public HotelReservationNew.Models.Context.HotelReservationNewDBContext db;

        public BaseController()
        {
            db = new Models.Context.HotelReservationNewDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}