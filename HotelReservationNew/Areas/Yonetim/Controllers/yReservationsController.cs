using HotelReservationNew.Areas.Yonetim.Models.Attributes;
using HotelReservationNew.Areas.Yonetim.Models.ManagementView;
using HotelReservationNew.Controllers;
using HotelReservationNew.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationNew.Areas.Yonetim.Controllers
{
    [_SessionLoginControl]
    public class yReservationsController : BaseController
    {
        // GET: Yonetim/yReservations

        ManageView mymodel = new ManageView();
      
        public ActionResult Index()
        {
            mymodel.Reservations = db.Reservations.ToList();

            return View(mymodel);
        }

        public ActionResult Edit(int ID)
        {
            mymodel.Reservations = db.Reservations.Where(x => x.ID == ID);

            return View(mymodel);
        }

        [HttpPost]
        public ActionResult EditReservation(Reservation model)
        {
            Reservation entity = db.Reservations.FirstOrDefault(x => x.ID == model.ID);
            entity.ReserveDateBegin = model.ReserveDateBegin;
            entity.ReserveDateEnd = model.ReserveDateEnd;
            db.SaveChanges();



            return RedirectToAction("Index", "yReservations");
        }

        public ActionResult DeleteReservation(int ID)
        {
            Reservation entity = db.Reservations.FirstOrDefault(x => x.ID ==ID);
            Room roometity = db.Rooms.FirstOrDefault(x => x.ID == entity.RoomID);
            roometity.Availability = true;
            entity.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index", "yReservations");
        }
    }
}