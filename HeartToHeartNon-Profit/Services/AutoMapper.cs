using AutoMapper;
using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Services
{
    public class AutoMapper : Profile 
    {
        public AutoMapper()
        {
            CreateMap<Campaign, ListCampaign>()
                .ForMember(d => d.UserName, option => option
                 .MapFrom(src => src.Admin.UserName));
            CreateMap<User, ProfileOutput>();
        }
    }
}
