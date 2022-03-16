using HotelReservationNew.Areas.Yonetim.Models.Attributes;
using HotelReservationNew.Areas.Yonetim.Models.ManagementView;
using HotelReservationNew.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationNew.Areas.Yonetim.Controllers
{
    [_SessionLoginControl]
    public class yUsersController : BaseController
    {

        ManageView mymodel = new ManageView();
        public ActionResult Index()
        {
            mymodel.Users = db.Users.ToList();

            return View(mymodel);
        }

        public ActionResult DeleteUser(int ID)
        {
            HotelReservationNew.Models.Data.User entity = db.Users.FirstOrDefault(x => x.ID == ID);
            entity.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index", "yUsers");
        }
        public ActionResult ActivateUser(int ID)
        {
            HotelReservationNew.Models.Data.User entity = db.Users.FirstOrDefault(x => x.ID == ID);
            entity.IsDelete = false;
            db.SaveChanges();
            return RedirectToAction("Index", "yUsers");
        }
    }
}