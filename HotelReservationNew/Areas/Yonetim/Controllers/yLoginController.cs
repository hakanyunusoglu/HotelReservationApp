using HotelReservationNew.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelReservationNew.Areas.Yonetim.Controllers
{
    public class yLoginController : HotelReservationNew.Controllers.BaseController
    {
        // GET: Yonetim/yLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(HttpContext.Response.Cookies["User"].Value))
            {
                return View();
            }
            else
            { 
                return RedirectToAction("Index", "yHome");
            }

        }
        [HttpPost]
       public ActionResult Login(Admin model)
        {

            if (ModelState.IsValid)
            {
                if (db.Admin.Any(x => x.Username == model.Username && x.Password == model.Password && x.IsDelete == false))
                {
                    string username = HttpContext.User.Identity.Name.ToString();
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    string loggedUser = model.Username;

                    HttpCookie cookieUser = new HttpCookie("User", loggedUser);
                    HttpContext.Response.Cookies.Add(cookieUser);


                    return RedirectToAction("Index", "yHome");
                }
                else
                {
                    ViewData["message"] = "true";
                    return View();
                }
            }
            






            return View();

        }
        public ActionResult SignOut()
        {
            var c = new HttpCookie("User");
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "yLogin");
        }


    }
}