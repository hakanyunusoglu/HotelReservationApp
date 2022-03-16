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
    public class yMailboxController : BaseController
    {

        ManageView mymodel = new ManageView();
        public ActionResult Index()
        {
            mymodel.Contacts = db.Contact.ToList();

            return View(mymodel);
        }

        public ActionResult DeleteMail(int ID)
        {
            HotelReservationNew.Models.Data.Contact entity = db.Contact.FirstOrDefault(x => x.ID == ID);
            entity.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index", "yMailbox");
        }
        public ActionResult ActivateMail(int ID)
        {
            HotelReservationNew.Models.Data.Contact entity = db.Contact.FirstOrDefault(x => x.ID == ID);
            entity.IsDelete = false;
            db.SaveChanges();
            return RedirectToAction("Index", "yMailbox");
        }
    }
}