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
        /// get list campaign from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Campaign>> GetListCampaign(int userId);
    }
}
