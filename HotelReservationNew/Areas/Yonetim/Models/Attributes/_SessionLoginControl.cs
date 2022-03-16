using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationNew.Areas.Yonetim.Models.Attributes
{
    public class _SessionLoginControl : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request.Cookies["User"].Value.ToString()))
            {
                 
                    if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                        filterContext.HttpContext.Response.Redirect("/Yonetim/yLogin/Login");

            }
        }
    }
}