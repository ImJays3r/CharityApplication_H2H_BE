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
        /// get campaign detail
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<Campaign> GetCampaignDetail(int campaignId)
        {
            var campaign = await _context.Campaigns.Where(a => a.CampaignId == campaignId).FirstOrDefaultAsync();
            return campaign;
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

        /// <summary>
        /// get total task
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<int> GetTotalTask(int campaignId)
        {
            int totalTask;
            var CampaignTask = await _context.Tasks
                .Include(c => c.Campaign)
                .Where(u => u.CampaignId == campaignId)
                .ToListAsync();
            totalTask = CampaignTask.Count();
            return totalTask;
        }

        /// <summary>
        /// get total participant
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<int> GetTotalParticipant(int campaignId)
        {
            int totalMember;
            int totalManager;
            int totalParticipant;

            var campaignMember = await _context.CampaignMembers
                .Include(c => c.Campaign)
                .Where(u => u.CampaignId == campaignId)
                .ToListAsync();
            totalMember = campaignMember.Count();
            var campaignManager = await _context.CampaignManagers
                .Include(c => c.Campaign)
                .Where(u => u.CampaignId == campaignId)
                .ToListAsync();
            totalManager = campaignManager.Count();

            totalParticipant = totalMember + totalManager + 1;

            return totalParticipant;
        }

        /// <summary>
        /// get total report
        /// </summary>
        /// <param name="TaskList"></param>
        /// <returns></returns>
        public async Task<int> GetTotalReport(IEnumerable<Models.Data.Task> TaskList)
        {
            int totalReprot = 0 ;

            foreach (var task in TaskList)
            {
                int total;
                var reportTask = await _context.Reports
                .Include(c => c.Task)
                .Where(u => u.TaskId == task.TaskId)
                .ToListAsync();
                total = reportTask.Count();
                totalReprot = totalReprot + total;
            }
            return totalReprot;
        }

        /// <summary>
        /// get task list of campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Data.Task>> GetListTask(int campaignId)
        {
            var CampaignTaskList = await _context.Tasks
                .Include(c => c.Campaign)
                .Where(u => u.CampaignId == campaignId)
                .ToListAsync();
            return CampaignTaskList;
        }
    }
}
