using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public CampaignManageRepository(HeartToHeartContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Create New Campaign return id
        /// </summary>
        /// <param name="camIn"></param>
        /// <returns></returns>
        public async Task<int> CreateCampaign(CreateCampaignInput camIn)
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
                Photourl = null,
                Status = true
            };
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
            return  campaign.CampaignId;
        }

        /// <summary>
        /// update campaign picture
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> UpdateCamPicture(UpdatePictureCampaignInput input)
        {
            try
            {
                var campaign = await _context.Campaigns.Where(a => a.CampaignId == input.CampaignId).FirstOrDefaultAsync();
                if (campaign != null)
                {
                    campaign.Photourl = input.Photourl;
                }
                if (await _context.SaveChangesAsync() > 0)
                    return 1;
                return 3;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
