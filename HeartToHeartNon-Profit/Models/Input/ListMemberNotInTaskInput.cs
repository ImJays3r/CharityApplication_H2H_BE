using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class ListMemberNotInTaskInput
    {
        /// <summary>
        /// campaign id
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// task Id
        /// </summary>
        public int TaskId { get; set; }
    }
}
