using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabSameSiteCookie.Controllers
{
    public class DemoCompController : Controller
    {
        private const string cookieName = "samesite_DemoComp";

        // GET: DemoComp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string SameSiteValue)
        {
            HttpCookie cookie = new HttpCookie(cookieName, "value"); ;
            switch(SameSiteValue)
            {
                case "Lax":
                    cookie.SameSite = SameSiteMode.Lax;
                    break;
                case "Strict":
                    cookie.SameSite = SameSiteMode.Strict;
                    break;
                case "None":
                    cookie.SameSite = SameSiteMode.None;
                    break;
                default:
                    break;
            }
            Response.SetCookie(cookie);

            return View();
        }
    }
}