using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListReportCampaign
    {
        /// <summary>
        /// task id
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// title match task title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// type match task type
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// start date
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// end date
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// picture of the first report 
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// total value of all report of a task
        /// </summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool Status { get; set; }
    }
}
