﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Areas.Fans.Models
{
    public class VMFanProfile
    {
        public string Username { get; set; }
        public List<Bands> Bands { get; set; }
        public List<News> News { get; set; }
        public List<Eventos> Eventos { get; set; }
    }
}