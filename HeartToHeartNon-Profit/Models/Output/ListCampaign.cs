using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListCampaign
    {
        /// <summary>
        /// campaign id
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// title of campaign
        /// </summary>
        public string Title { get; set; }

        //campaign type longterm or short term
        public string Type { get; set; }

        /// <summary>
        /// budget
        /// </summary>
        public decimal Budget { get; set; }

        /// <summary>
        /// little description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// name of admin who create campaign
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// end date
        /// </summary
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// status of campaign
        /// </summary>
        public bool Status { get; set; }
    }
}
