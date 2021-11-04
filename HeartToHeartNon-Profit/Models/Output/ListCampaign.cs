using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListCampaign
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public decimal Budget { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Status { get; set; }
    }
}
