using HotelReservationNew.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelReservationNew.Models.Data;
using HotelReservationNew.Models.Context;
using System.Web.Security;
using HotelReservationNew.Models.ViewModels;
using System.Web.Helpers;
using HotelReservationNew.Models.Error;

namespace HotelReservationNew.Controllers
{
    public class ContactController : Controller
    {
        HotelReservationNewDBContext db = new HotelReservationNewDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public void MailSender(string mail)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "hakan.biltek@gmail.com";
                WebMail.Password = "h1114506011h";
                WebMail.SmtpPort = 587;
                WebMail.Send(
                        mail,
                        "Hakan Hotel iletisim",
                        "Bizimle iletisime gectiğiniz icin tesekkur ederiz. Size en yakin sürede geri donus yapacagimizi bildiririz.",
                        "Iyı gunler dileriz."

                    );

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult SendMessage(Contact model)
        {
            try
            {
                Contact contact = new Contact();
                contact.Name = model.Name;
                contact.Email = model.Email;
                contact.Phone = model.Phone;
                contact.Subject = model.Subject;
                contact.Message = model.Message;
                db.Contact.Add(contact);
                db.SaveChanges();
                MailSender(model.Email);
                return RedirectToAction("SuccessMail", "Contact");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}