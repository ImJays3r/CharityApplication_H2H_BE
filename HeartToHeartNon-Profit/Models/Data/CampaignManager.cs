using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class CampaignManager
    {
        public int CampaignId { get; set; }
        public int ManagerId { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual User Manager { get; set; }
    }
}
