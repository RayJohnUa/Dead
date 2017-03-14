using DeadEntity;
using DeadProject.attr;
using DeadProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadProject.AppControllers
{
    [AuthorizeRoles(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        public UserEntity CurentUser = CurentUserHelper.GetcurrentUser();
    }
}