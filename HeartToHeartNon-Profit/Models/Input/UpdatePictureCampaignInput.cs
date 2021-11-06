using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class UpdatePictureCampaignInput
    {
        /// <summary>
        /// campaign ID
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// photo url
        /// </summary>
        public string Photourl { get; set; }
    }
}
