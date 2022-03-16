using HotelReservationNew.Areas.Yonetim.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationNew.Areas.Yonetim.Controllers
{
    [_SessionLoginControl]
    public class yHomeController : Controller
    {
        // GET: Yonetim/yHome
       
        public ActionResult Index()
        {
            return View();
        }
    }
}