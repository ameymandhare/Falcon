using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FalconSchool.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Home()
        {
            return View();
        }

        // GET: Dashboard
        public ActionResult Blank()
        {
            return View();
        }
    }
}