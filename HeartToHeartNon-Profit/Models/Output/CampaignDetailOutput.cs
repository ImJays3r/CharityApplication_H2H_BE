using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class CampaignDetailOutput
    {
        /// <summary>
        /// campaign Id
        /// </summary>
        public int CampaignId { get; set; }
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// type 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// budget
        /// </summary>
        public decimal Budget { get; set; }
        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// creator id 
        /// </summary>
        public int AdminId { get; set; }
        /// <summary>
        /// start date
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// end date
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// create date
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// status
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// photo url
        /// </summary>
        public string Photourl { get; set; }
        /// <summary>
        /// total participant
        /// </summary>
        public int totalParticipant { get; set; }
        /// <summary>
        /// total task
        /// </summary>
        public int totalTask { get; set; }
        /// <summary>
        /// total report
        /// </summary>
        public int totalReport { get; set; }
    }
}
