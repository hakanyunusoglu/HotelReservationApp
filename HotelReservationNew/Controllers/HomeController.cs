using HotelReservationNew.Models.Context;
using HotelReservationNew.Models.Data;
using HotelReservationNew.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationNew.Controllers
{
    public class HomeController : Controller
    {
        HomeViewModel mymodel = new HomeViewModel();
        HotelReservationNewDBContext db = new HotelReservationNewDBContext();
        // GET: Home

        public ActionResult Index()
        {

             mymodel.Rooms = db.Rooms.ToList();
            return View(mymodel);
        }



    }
}