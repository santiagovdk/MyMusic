﻿using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Bands.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class EventsController : Controller
    {
        // GET: Bands/Events
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Create(int userId)
        {
            string response = await clsBandRequests.getBandAlbums(userId);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Something wrong with, create event";
            }

            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();

            profile.Albums = DataParser.parseAlbums(response);

            return View(profile);
        }

    }
}