using HeartToHeartNon_Profit.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories.Interfaces
{
    public interface ICampaignManageRepository
    {
        /// <summary>
        /// Create new Campaign
        /// </summary>
        /// <param name="camIn"></param>
        /// <returns></returns>
        Task<int> CreateCampaign(CreateCampaignInput camIn);

        /// <summary>
        /// update picture when create campaign
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<int> UpdateCamPicture(UpdatePictureCampaignInput input);
    }
}
