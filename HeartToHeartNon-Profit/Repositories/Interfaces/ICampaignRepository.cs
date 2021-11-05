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
    }
}
