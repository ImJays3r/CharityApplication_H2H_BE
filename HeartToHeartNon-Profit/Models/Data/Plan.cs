using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class Plan
    {
        public int PlanId { get; set; }
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
