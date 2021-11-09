using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class AddParticipantToCampaignInput
    {
        /// <summary>
        /// id of campaign
        /// </summary>
        public int campaignId { get; set; }

        /// <summary>
        /// list user added to campaign
        /// </summary>
        public virtual ICollection<int> listUser { get; set; }
    }
}
