using AutoMapper;
using EmlakOfisi.Entities;
using EmlakOfisi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfisi.WebUI
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<AdvertisementModel, Advertisement>();
            CreateMap<Advertisement, AdvertisementModel>();
            CreateMap<Agent, AgentModel>();
            CreateMap<AgentModel, Agent>();


        }
    }
}
