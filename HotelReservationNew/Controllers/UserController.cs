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
    public class UserController : Controller
    {

        HotelReservationNewDBContext db = new HotelReservationNewDBContext();
        // GET: User
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
                        "Hakan Hotel üyelik kaydı",
                        "Üyeliğiniz başarıyla gerçekleşmiştir. Sitemize "+ mail+" mail adresi ile giriş yapabilirsiniz."
                        
                    );
                 
            }
            catch (Exception ex)
            {
                throw;
            }
             
        }

        
        public ActionResult Register(UserRegisterVM model)
        {
            try
            {
                User user = new User();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Password = model.Password;
                user.Mail = model.Mail; ;
                db.Users.Add(user);
                db.SaveChanges();
                MailSender(model.Mail);
                return RedirectToAction("SuccessRegister", "User");
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public ActionResult Login(UserLoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.Mail == model.Mail && x.Password == model.Password && x.IsDelete ==false))
                {
                    FormsAuthentication.SetAuthCookie(model.Mail.ToString(), true);
                    HotelReservationNew.Models.Data.User user  = db.Users.FirstOrDefault(x => x.Mail == model.Mail && x.IsDelete ==false);
                    HttpCookie cookieUser = new HttpCookie("SiteUser", user.Mail.ToString());
                    HttpContext.Response.Cookies.Add(cookieUser);

                    HttpCookie cookieUserName = new HttpCookie("SiteUserName", user.Name.ToString());
                    HttpContext.Response.Cookies.Add(cookieUserName);


                    Session["message"] = "false";
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    Session["message"] = "true";
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignOut()
        {
            var c = new HttpCookie("SiteUser");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);

            var c1 = new HttpCookie("SiteUserName");
            c1.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c1);


            FormsAuthentication.SignOut();
           
            return RedirectToAction("Index", "Home");
        }

        HomeViewModel model = new HomeViewModel();
        public List<User> GetUserByLoggedMail(string mail)
        {
            List<User> user = db.Users.Where(x => x.Mail == mail).ToList();
            return user;
        }

        [ChildActionOnly]
        public ActionResult LoggedUser()
        {
            model.Users = GetUserByLoggedMail(HttpContext.Request.Cookies["SiteUser"].ToString());
            return View("~/Views/Shared/Partial/_LoggedUser.cshtml", model);
        }


        public ActionResult SuccessRegister()
        {
            return View();
        }

        [_SessionLoginControl]
        public ActionResult UserProfile()
        {

            string usermail = HttpContext.Request.Cookies["SiteUser"].Value ;
            HomeViewModel mymodel = new HomeViewModel();
            int UserID = db.Users.FirstOrDefault(x => x.Mail == usermail && x.IsDelete==false).ID;



            mymodel.Users = db.Users.Where(x => x.Mail == usermail).ToList();
            mymodel.CreditCards = db.CreditCards.Where(x => x.UserID == UserID && x.IsDelete==false).ToList();
            mymodel.Reservations = db.Reservations.Where(x => x.UserID == UserID && x.IsDelete == false).ToList();


            return View(mymodel);
        }
        




        [HttpPost]
        public ActionResult EditProfile(User model)
        { 
            try
            {

                string usermail = HttpContext.Request.Cookies["SiteUser"].Value;
                HotelReservationNew.Models.Data.User entity = db.Users.FirstOrDefault(x => x.Mail == usermail && x.IsDelete == false);
                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Country = model.Country;
                entity.PostalCode = model.PostalCode;
                entity.Surname = model.Surname;
                entity.Adres = model.Adres;
                entity.Region = model.Region;
                entity.UpdatedDate = DateTime.Now;
                db.SaveChanges();

                TempData["Process"] = "Show";
                TempData["AlertType"] = "success";
                TempData["ProcessMessage"] = "Profil bilgilerinizi başarıyla güncelleştirdik.";
                return RedirectToAction("UserProfile", "User");
            }
            catch (Exception)
            {
                TempData["Process"] = "Show";
                TempData["AlertType"] = "danger";
                TempData["ProcessMessage"] = "Profil bilgilerinizi güncellenirken bir hata ile karşılaştık. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction("UserProfile", "User");
            }


            
        }
        public ActionResult ChangePassword(UserLoginVM model)
        {

            try
            {
                string usermail = HttpContext.User.Identity.Name;
                HotelReservationNew.Models.Data.User entity = db.Users.FirstOrDefault(x => x.Mail == usermail && x.IsDelete == false);
                entity.Password = model.Password;
                entity.UpdatedDate = DateTime.Now;
                db.SaveChanges();

                TempData["Process"] = "Show";
                TempData["AlertType"] = "success";
                TempData["ProcessMessage"] = "Şifrenizi başarıyla güncelleştirdik.";
            }
            catch (Exception)
            {

                TempData["Process"] = "Show";
                TempData["AlertType"] = "danger";
                TempData["ProcessMessage"] = "Şifreniz güncellenirken bir hata ile karşılaştık. Lütfen daha sonra tekrar deneyin.";
            }



            return RedirectToAction("UserProfile", "User");
        }

        public ActionResult AddCreditCard(CreditCards model)
        {

            string usermail = HttpContext.User.Identity.Name;
            int UserID = db.Users.FirstOrDefault(x => x.Mail == usermail && x.IsDelete == false).ID;

            try
            {
                HotelReservationNew.Models.Data.CreditCards entity = new CreditCards();
                entity.Number = model.Number;
                entity.UserID = UserID;
                entity.Validate = model.Validate;
                entity.HolderName = model.HolderName;
                db.CreditCards.Add(entity);
                db.SaveChanges();
                TempData["Process"] = "Show";
                TempData["AlertType"] = "success";
                TempData["ProcessMessage"] = "Kredi Kartı eklendi.";
            }
            catch (Exception)
            {
                TempData["Process"] = "Show";
                TempData["AlertType"] = "danger";
                TempData["ProcessMessage"] = "Kredi Kartı eklenirken bir hata ile karşılaştık. Lütfen daha sonra tekrar deneyin.";
               
            }

            return RedirectToAction("UserProfile", "User");



             
        }

        public ActionResult DeleteCreditCard(int ID)
        {
            string usermail = HttpContext.User.Identity.Name;
            int UserID = db.Users.FirstOrDefault(x => x.Mail == usermail && x.IsDelete == false).ID;

            try
            {
                HotelReservationNew.Models.Data.CreditCards entity = db.CreditCards.FirstOrDefault(x => x.ID == ID && x.UserID == UserID);
                entity.IsDelete = true;
                db.SaveChanges();

                TempData["Process"] = "Show";
                TempData["AlertType"] = "success";
                TempData["ProcessMessage"] = "Kredi Kartı silindi.";
            }
            catch (Exception)
            {

                TempData["Process"] = "Show";
                TempData["AlertType"] = "danger";
                TempData["ProcessMessage"] = "Kredi Kartı silinirken bir hata ile karşılaştık. Lütfen daha sonra tekrar deneyin.";
            }


            return RedirectToAction("UserProfile", "User");
        }

    }
}