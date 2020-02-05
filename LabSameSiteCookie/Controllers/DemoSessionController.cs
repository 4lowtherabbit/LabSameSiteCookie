using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabSameSiteCookie.Controllers
{
    public class DemoSessionController : Controller
    {
        // GET: DemoSession
        public ActionResult Index()
        {
            Session["SameSite_SessionKey"] = "value";
            return View();
        }
    }
}