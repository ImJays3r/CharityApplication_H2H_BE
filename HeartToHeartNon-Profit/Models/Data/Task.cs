using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class Task
    {
        public Task()
        {
            Reports = new HashSet<Report>();
        }

        public int TaskId { get; set; }
        public int ManagerId { get; set; }
        public string Title { get; set; }
        public string TaskType { get; set; }
        public string ItemType { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CampaignId { get; set; }
        public bool Status { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
