using DeadEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadProject.AppControllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        
    }
}