using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HeartToHeartNon_Profit.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly HeartToHeartContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public CampaignRepository(HeartToHeartContext context)
        {
            _context = context;

        }

        /// <summary>
        /// get list campaign all status for admin 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Campaign>> GetListCampaign(int userId)
        {
            var campaign = await _context.Campaigns
                .Include(u => u.Admin)
                .Where(a => a.AdminId == userId)
                .ToListAsync();
            return campaign;
        }

        /// <summary>
        /// get list campaign all status for manager
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CampaignManager>> GetListCampaignManager(int userId)
        {
            var campaignManager = await _context.CampaignManagers
                .Include(c => c.Campaign)
                .Where(u => u.ManagerId == userId)
                .ToListAsync();
                
            return campaignManager;
        }

        /// <summary>
        /// get list campaign all status for member
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CampaignMember>> GetListCampaignMember(int userId)
        {
            var campaignMember = await _context.CampaignMembers
                .Include(c => c.Campaign)
                .Where(u => u.MemberId == userId)
                .ToListAsync();

            return campaignMember;
        }
    }
}
