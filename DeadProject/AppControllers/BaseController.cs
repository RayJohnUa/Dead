﻿using DeadEntity;
using DeadEntity.IRepository;
using DeadProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeadProject.AppControllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public static UserEntity CurentUser = CurentUserHelper.GetcurrentUser();
    }
}