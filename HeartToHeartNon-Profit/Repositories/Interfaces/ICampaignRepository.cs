using HeartToHeartNon_Profit.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories.Interfaces
{
    public interface ICampaignRepository
    {
        /// <summary>
        /// get list campaign from database by admin
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Campaign>> GetListCampaign(int userId);

        /// <summary>
        /// get list campaign from database by manager
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CampaignManager>> GetListCampaignManager(int userId);

        /// <summary>
        /// get list campaign from database by member
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CampaignMember>> GetListCampaignMember(int userId);

        /// <summary>
        /// get campaign detail
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        Task<Campaign> GetCampaignDetail(int campaignId);

        /// <summary>
        /// get total participant
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        Task<int> GetTotalParticipant(int campaignId);

        /// <summary>
        /// get total task
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        Task<int> GetTotalTask(int campaignId);

        /// <summary>
        /// get list task of campaign
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Data.Task>> GetListTask(int campaignId);

        /// <summary>
        /// get list member of campaign
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CampaignMember>> GetListMember(int campaignId);

        /// <summary>
        /// get list manager of campaign
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CampaignManager>> GetListManager(int campaignId);

        /// <summary>
        /// get admin information for list participant
        /// </summary>
        /// <returns></returns>
        Task<Campaign> GetAdminForList(int campaignId);

        /// <summary>
        /// get total Report
        /// </summary>
        /// <param name="TaskList"></param>
        /// <returns></returns>
        Task<int> GetTotalReport(IEnumerable<Models.Data.Task> TaskList);
    }
}
