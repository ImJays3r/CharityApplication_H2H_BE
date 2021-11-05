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
                 .MapFrom(src => src.Admin.UserName))
                .ForMember(d => d.StartDate, option => option
                .MapFrom(src => src.StartDate.ToString("dd-MM-yyyy")))
                .ForMember(c => c.EndDate, option => option
                .MapFrom(src => src.EndDate.ToString("dd-MM-yyyy")));

            CreateMap<CampaignManager, ListCampaign>()
               .ForMember(d => d.UserName, option => option
                .MapFrom(src => src.Manager.UserName))
               .ForMember(d => d.StartDate, option => option
               .MapFrom(src => src.Campaign.StartDate.ToString("dd-MM-yyyy")))
               .ForMember(c => c.EndDate, option => option
               .MapFrom(src => src.Campaign.EndDate.ToString("dd-MM-yyyy")))
               .ForMember(c => c.CampaignId, option => option
               .MapFrom(src => src.Campaign.CampaignId))
               .ForMember(c => c.Type, option => option
               .MapFrom(src => src.Campaign.Type))
               .ForMember(c => c.Title, option => option
               .MapFrom(src => src.Campaign.Title))
               .ForMember(c => c.Budget, option => option
               .MapFrom(src => src.Campaign.Budget))
               .ForMember(c => c.Description, option => option
               .MapFrom(src => src.Campaign.Description))
               .ForMember(c => c.Location, option => option
               .MapFrom(src => src.Campaign.Location))
               .ForMember(c => c.Status, option => option
               .MapFrom(src => src.Campaign.Status))
               .ForMember(c => c.Photourl, option => option
               .MapFrom(src => src.Campaign.Photourl));

            CreateMap<CampaignMember, ListCampaign>()
               .ForMember(d => d.UserName, option => option
                .MapFrom(src => src.Member.UserName))
               .ForMember(d => d.StartDate, option => option
               .MapFrom(src => src.Campaign.StartDate.ToString("dd-MM-yyyy")))
               .ForMember(c => c.EndDate, option => option
               .MapFrom(src => src.Campaign.EndDate.ToString("dd-MM-yyyy")))
               .ForMember(c => c.CampaignId, option => option
               .MapFrom(src => src.Campaign.CampaignId))
               .ForMember(c => c.Type, option => option
               .MapFrom(src => src.Campaign.Type))
               .ForMember(c => c.Title, option => option
               .MapFrom(src => src.Campaign.Title))
               .ForMember(c => c.Budget, option => option
               .MapFrom(src => src.Campaign.Budget))
               .ForMember(c => c.Description, option => option
               .MapFrom(src => src.Campaign.Description))
               .ForMember(c => c.Location, option => option
               .MapFrom(src => src.Campaign.Location))
               .ForMember(c => c.Status, option => option
               .MapFrom(src => src.Campaign.Status))
               .ForMember(c => c.Photourl, option => option
               .MapFrom(src => src.Campaign.Photourl));

            CreateMap<User, ProfileOutput>()
                .ForMember(d => d.DateOfBirth, option => option
                .MapFrom(src => src.DateOfBirth.ToString("dd-MM-yyyy")));
        }
    }
}
