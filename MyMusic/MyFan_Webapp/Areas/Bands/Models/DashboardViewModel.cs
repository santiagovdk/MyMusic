﻿namespace MyFan_Webapp.Models
{
    public class DashboardViewModel
    {
        public int Calification { get; set; }
        public int Disco { get; set; }
        public int Eventos { get; set; }
        public int Followers { get; set; }

        public DTO.clsInfoBand  Info { get; set; }
        public int Id { get; set; }

    }
}