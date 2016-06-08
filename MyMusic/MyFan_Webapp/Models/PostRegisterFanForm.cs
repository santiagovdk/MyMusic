﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp
{
    public class PostRegisterFanForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public List<string> Genres { get; set; }
        public string accept { get; set; }

    }
}