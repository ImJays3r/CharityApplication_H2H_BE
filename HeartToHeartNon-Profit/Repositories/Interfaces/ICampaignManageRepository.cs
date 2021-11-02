using HeartToHeartNon_Profit.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories.Interfaces
{
    interface ICampaignManageRepository
    {
        /// <summary>
        /// Create new Campaign
        /// </summary>
        /// <param name="camIn"></param>
        /// <returns></returns>
        Task<bool> CreateCampaign(CreateCampaignInput camIn);
    }
}
