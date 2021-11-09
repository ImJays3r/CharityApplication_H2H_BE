using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListReportTask
    {
        /// <summary>
        /// report id
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// belong to task id
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// member id , id of creator
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// report type match task type
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// value of report
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// status of report, false = chua duyet , true = da duyet
        /// </summary>
        public bool Status { get; set; }
    }
}
