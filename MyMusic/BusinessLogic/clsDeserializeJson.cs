﻿using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class clsDeserializeJson
    {
        public clsInfoFan DeserializeFanForm(string pstringData)
        {
            clsInfoFan InfoFan = new clsInfoFan();
            dynamic data = JObject.Parse(pstringData);

            InfoFan.Active = true;
            InfoFan.Birthday = Convert.ToString(data.Birthday);
            InfoFan.Country = Convert.ToString(data.Country);
            InfoFan.Gender = Convert.ToString(data.Gender);
            InfoFan.Genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.Genres));
            InfoFan.Name = Convert.ToString(data.Name);
            InfoFan.Password = Convert.ToString(data.Password);
            InfoFan.Username = Convert.ToString(data.Username);

            return InfoFan;
        }

        public clsInfoBand DeserializeBandForm(string pstringData)
        {
            clsInfoBand InfoBand = new clsInfoBand();
            dynamic data = JObject.Parse(pstringData);
            

            InfoBand.Active = true;
            InfoBand.DateCreation = Convert.ToString(data.DateCreation);
            InfoBand.Country = Convert.ToString(data.Country);
            InfoBand.Hashtag = Convert.ToString(data.Hashtag);
            InfoBand.Genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.Genres));
            InfoBand.Name = Convert.ToString(data.Name);
            InfoBand.Members = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.Members));
            InfoBand.Biography = Convert.ToString(data.Biography);
            InfoBand.Password = Convert.ToString(data.Password);
            InfoBand.Username = Convert.ToString(data.Username);

            return InfoBand;
        }
    }
}