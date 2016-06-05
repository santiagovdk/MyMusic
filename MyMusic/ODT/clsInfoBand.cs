﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsInfoBand:IUser
    {
        public String Name { get; set; }
        public String DateCreation { get; set; }
        public List<String> Genres { get; set; }
        public String Country { get; set; }
        public String Hashtag { get; set; }
        public List<clsMember> Members { get; set; }

        //interface atributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Rol { get; set; }
        public bool Active { get; set; }

        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public String ErrorMessage { get; set; }

        public string SaltHashed
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public String toJson()
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            String json = "Success:" + Success + "," + "ErrorCode:" + ErrorCode + "," + "ErrorMessage:" + ErrorMessage + "," + "Data:";
            String data = javaScriptSerializer.Serialize(this);
            json += data;
            return json;
        }
    }
}