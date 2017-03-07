using DeadProject.AppControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadProject.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}