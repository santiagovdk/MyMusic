﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class NewsController : Controller
    {
        // GET: Bands/News
        public ActionResult Index(int userId, int id)
        {
            System.Diagnostics.Debug.WriteLine("check band from " + userId + " with new " + id);
            return View();
        }
    }
}