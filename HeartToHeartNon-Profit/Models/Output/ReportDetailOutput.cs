using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ReportDetailOutput
    {
        /// <summary>
        /// list photo of Report
        /// </summary>
        public ICollection<string> photoUrl { get; set; }

        /// <summary>
        /// report id
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// task id
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// member id
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// report type
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool Status { get; set; }
    }
}
