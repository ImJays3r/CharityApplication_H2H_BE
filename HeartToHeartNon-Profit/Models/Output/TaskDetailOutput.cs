using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class TaskDetailOutput
    {
        /// <summary>
        /// task id
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// manager Creator Id
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// task Type
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// start day
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// end day
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// campaign id
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool Status { get; set; }
    }
}
