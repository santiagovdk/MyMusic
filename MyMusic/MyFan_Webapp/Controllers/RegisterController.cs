﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Fan()
        {
            return View();
        }

        public ActionResult Band()
        {
            return View();
        }
    }
}