using HotelReservationNew.Areas.Yonetim.Models.Attributes;
using HotelReservationNew.Areas.Yonetim.Models.ManagementView;
using HotelReservationNew.Controllers;
using HotelReservationNew.Models.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationNew.Areas.Yonetim.Controllers
{
    [_SessionLoginControl]
    public class yRoomsController : BaseController
    {
        ManageView mymodel = new ManageView();
        public ActionResult Index()
        {
            mymodel.Rooms = db.Rooms.ToList();

            return View(mymodel);
        }

        public ActionResult Gallery(int ID)
        {
            return View();
        }
        public ActionResult AddRoom()
        {
            return View();
        }

        public ActionResult DeleteRoom(int ID)
        {
            Room entity = db.Rooms.FirstOrDefault(x => x.ID == ID);
            entity.IsDelete = true;
            RoomPicture picentit = db.RoomPicture.FirstOrDefault(x => x.RoomID == ID);
            picentit.IsDelete = true;
            db.SaveChanges();

            return RedirectToAction("Index", "yRooms");
        }
        public ActionResult ActivateRoom(int ID)
        {
            Room entity = db.Rooms.FirstOrDefault(x => x.ID == ID);
            entity.IsDelete = false;
            RoomPicture picentit = db.RoomPicture.FirstOrDefault(x => x.RoomID == ID);
            picentit.IsDelete = false;
            db.SaveChanges();
            return RedirectToAction("Index", "yRooms");

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult RoomAdd(RoomVM model)
        {
            Room entity = new Room();
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Availability = true;
            entity.Bed = model.Bed;
            entity.Floor = model.Floor;
            entity.MaxAdult = model.MaxAdult;
            entity.MaxChild = model.MaxChild;
            entity.CoverImage = "a";
            entity.Counter = 0;

            db.Rooms.Add(entity);
            db.SaveChanges();

            int RoomID = entity.ID;

            Room roomCoverImage = db.Rooms.FirstOrDefault(x => x.ID == RoomID);
            RoomPicture roomSliders = new RoomPicture();

            string fileName = "";
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[1];

            if (Request.Files.Count > 0)
            {
                fileName = file.FileName.Replace(' ', '-');
                Directory.CreateDirectory(Server.MapPath("~/images/RoomPictures/" + RoomID + "/"));
                file.SaveAs(Server.MapPath("~/images/RoomPictures/" + RoomID + "/" + fileName));
            }
            roomCoverImage.CoverImage = "/images/RoomPictures/" + RoomID + "/" + fileName;
            roomSliders.RoomID = RoomID;
            roomSliders.Url = "/images/RoomPictures/" + RoomID + "/" + fileName;
            db.RoomPicture.Add(roomSliders);
            db.SaveChanges();

            return RedirectToAction("Index", "yRooms");
        }


        public ActionResult EditRoom(int ID)
        {
            mymodel.Rooms = db.Rooms.Where(x => x.ID == ID);

            return View(mymodel);
        }

        [ValidateInput(false)]
        public ActionResult RoomEdit(RoomVM model)
        {
            Room entity = db.Rooms.FirstOrDefault(x => x.ID == model.ID);
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.Availability = true;
            entity.Bed = model.Bed;
            entity.Floor = model.Floor;
            entity.MaxAdult = model.MaxAdult;
            entity.MaxChild = model.MaxChild;
            
            db.SaveChanges();

            int RoomID = model.ID;

            Room roomCoverImage = db.Rooms.FirstOrDefault(x => x.ID == RoomID);
            RoomPicture roomSliders = db.RoomPicture.FirstOrDefault(x => x.ID == RoomID);

            string fileName = "";
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[1];

            if (Request.Files.Count > 0)
            {
                fileName = file.FileName.Replace(' ', '-');
                Directory.CreateDirectory(Server.MapPath("~/images/RoomPictures/" + RoomID + "/"));
                file.SaveAs(Server.MapPath("~/images/RoomPictures/" + RoomID + "/" + fileName));
            }
            roomCoverImage.CoverImage = "/images/RoomPictures/" + RoomID + "/" + fileName;
            roomSliders.RoomID = RoomID;
            roomSliders.Url = "/images/RoomPictures/" + RoomID + "/" + fileName;
             
            db.SaveChanges();

            return RedirectToAction("Index", "yRooms");
        }
    }
}