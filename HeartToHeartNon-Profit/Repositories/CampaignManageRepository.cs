using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories
{
    public class CampaignManageRepository : ICampaignManageRepository
    {
        private const string FormatDate = "dd-MM-yyyy";
        private readonly HeartToHeartContext _context;

        public CampaignManageRepository(HeartToHeartContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Create New Campaign 
        /// </summary>
        /// <param name="camIn"></param>
        /// <returns></returns>
        public async Task<bool> CreateCampaign(CreateCampaignInput camIn)
        {
            Campaign campaign = new()
            {
                AdminId = camIn.AdminId,
                Title = camIn.Title,
                Type = camIn.Type,
                Budget = camIn.Budget,
                CreateDate = DateTime.Now,
                StartDate = DateTime.ParseExact(camIn.StartDate, FormatDate, CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact(camIn.EndDate, FormatDate, CultureInfo.InvariantCulture),
                Description = camIn.Description,
                Location = camIn.Location,
                Status = true
            };
            await _context.Campaigns.AddAsync(campaign);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
