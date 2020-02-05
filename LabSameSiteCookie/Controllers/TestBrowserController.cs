using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabSameSiteCookie.Controllers
{
    public class TestBrowserController : Controller
    {
        private const string cookieName = "samesite_TestBrowser";

        // GET: TestBrowser
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string SameSiteValue)
        {
            HttpCookie cookie = new HttpCookie(cookieName, "value"); ;
            switch (SameSiteValue)
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

            return RedirectToAction("StepCookieSet");
        }

        public ActionResult StepCookieSet()
        {
            ViewBag.CurrentUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/TestBrowser/StepBackFromDiffSite/";
            return View();
        }

        public ActionResult StepBackFromDiffSite()
        {
            ViewBag.CookieName = cookieName;

            HttpCookie c = Request.Cookies[cookieName];
            ViewBag.CookieExists = Request.Cookies.AllKeys.Contains(cookieName);
            return View();
        }

    }
}