using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace LabSameSiteCookie.Controllers
{
    public class LaxAndStrictController : Controller
    {
        private const string cookieName = "samesite_LaxAndStrict";
        // GET: LaxAndStrict
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string SameSiteValue)
        {
            if (SameSiteValue.Equals("Lax", StringComparison.OrdinalIgnoreCase))
            {
                var cookie = new HttpCookie(cookieName, "value");
                cookie.SameSite = SameSiteMode.Lax;
                Response.SetCookie(cookie);
            }
            else
            {
                var cookie = new HttpCookie(cookieName, "value");
                cookie.SameSite = SameSiteMode.Strict;
                Response.SetCookie(cookie);
            }

            return RedirectToAction("StepCookieSet");
        }

        public ActionResult StepCookieSet()
        {
            ViewBag.CurrentUrl = $"{Request.Url.Scheme}://{Request.Url.Authority}/LaxAndStrict/StepBackFromDiffSite/";
            return View();
        }

        public ActionResult StepOnDiffSite(string returnUrl = "https://SameSiteCookie.azurewebsites.net/LaxAndStrict/StepBackFromDiffSite")
        {
            ViewBag.ReturnUrl = returnUrl;
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