using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignManagers = new HashSet<CampaignManager>();
            CampaignMembers = new HashSet<CampaignMember>();
            Tasks = new HashSet<Task>();
        }

        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int AdminId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public string Photourl { get; set; }

        public virtual User Admin { get; set; }
        public virtual ICollection<CampaignManager> CampaignManagers { get; set; }
        public virtual ICollection<CampaignMember> CampaignMembers { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
