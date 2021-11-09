using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class CampaignMember
    {
        public int CampaignId { get; set; }
        public int MemberId { get; set; }
        public int Id { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual User Member { get; set; }
    }
}
