using HotelReservationNew.Models.Error;
using HotelReservationNew.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationNew.Controllers
{
    public class RoomController : BaseController
    {
        HomeViewModel mymodel = new HomeViewModel();
        // GET: Room

        int pagesize = 9;
        public ActionResult Index(int? page, SearchViewModel searchmodelindex)
        {

            IEnumerable<HotelReservationNew.Models.Data.Room> model = null;
            int count; 

            if (!page.HasValue)
            {
                model = db.Rooms.OrderByDescending(x => x.ID).Take(pagesize);
                count = model.Count();
            }
             
            else
            {
                int pageindex = pagesize * page.Value;
                model = db.Rooms.Where(x => x.IsDelete == false).OrderBy(x => x.ID).Skip(pageindex).Take(pagesize);
                count = model.Count();
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Room/_RoomListItem.cshtml", model);

            } 
            return View(model);
        }


        //public ActionResult SearchEngine(SearchViewModel searchmodel)
        //{
        //    IEnumerable<HotelReservationNew.Models.Data.Room> model = db.Rooms.Where(x => x.IsDelete == false);
        //    int cout = model.Count();
        //    if (searchmodel.Price != 0)
        //    {
        //        model = db.Rooms.Where(x => x.Price <= searchmodel.Price);
        //    }
        //    if (searchmodel.RoomType != "Seçiniz" && searchmodel.RoomType != null)
        //    {
        //        model = db.Rooms.Where(x => x.RoomType == searchmodel.RoomType);
        //    }
        //    if (searchmodel.MaxAdult != 0)
        //    {
        //        model = db.Rooms.Where(x => x.MaxAdult >= searchmodel.MaxAdult);
        //    }
        //    if (searchmodel.MaxChild != 0)
        //    {
        //        model = db.Rooms.Where(x => x.MaxChild >= searchmodel.MaxChild);
        //    }

        //    if (searchmodel.Floor != 0)
        //    {
        //        model = db.Rooms.Where(x => x.Floor == searchmodel.Floor);
        //    }

        //    Session["searchmodel"] = model;

        //    return RedirectToAction("Index", "Room");
        //}







        public ActionResult Detail(int ID)
        {

            mymodel.Rooms = db.Rooms.Where(x => x.ID == ID && x.IsDelete == false);
            mymodel.RoomPictures = db.RoomPicture.Where(x => x.RoomID == ID).ToList();
            return View(mymodel);
        }

        [_SessionLoginControl]
        public ActionResult Payment(int ID)
        {
            string usermail = HttpContext.Request.Cookies["SiteUser"].Value;
            HomeViewModel mymodel = new HomeViewModel();
            int UserID = db.Users.FirstOrDefault(x => x.Mail == usermail && x.IsDelete == false).ID;



            mymodel.Users = db.Users.Where(x => x.Mail == usermail).ToList();
            mymodel.CreditCards = db.CreditCards.Where(x => x.UserID == UserID && x.IsDelete == false).ToList();
            mymodel.Reservations = db.Reservations.Where(x => x.UserID == UserID && x.IsDelete == false).ToList();
            mymodel.Rooms = db.Rooms.Where(x => x.ID == ID && x.IsDelete == false).ToList();

            return View(mymodel);

        }

        public ActionResult AddReservation(int ID)
        {
            string usermail = HttpContext.Request.Cookies["SiteUser"].Value;
            HomeViewModel mymodel = new HomeViewModel();
            int UserID = db.Users.FirstOrDefault(x => x.Mail == usermail && x.IsDelete == false).ID;

            HotelReservationNew.Models.Data.Reservation entity = new Models.Data.Reservation();
            HotelReservationNew.Models.Data.Room room = db.Rooms.FirstOrDefault(x => x.ID == ID && x.IsDelete == false);

            entity.UserID = UserID;
            entity.RoomID = ID;
            entity.OrderDate = DateTime.Now;
            room.Counter = room.Counter + 1;
            entity.ReserveDateBegin = DateTime.Now.AddDays(1);
            entity.ReserveDateEnd = DateTime.Now.AddDays(3);
            entity.Cost = Convert.ToInt32(entity.ReserveDateEnd.Day - entity.ReserveDateBegin.Day) * room.Price;
            room.Availability = false;
            db.Reservations.Add(entity);
            db.SaveChanges();




            return RedirectToAction("UserProfile", "User");
        }


    }
}