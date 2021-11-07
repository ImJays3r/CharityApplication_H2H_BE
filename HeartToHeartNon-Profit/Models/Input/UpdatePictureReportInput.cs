using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class UpdatePictureReportInput
    {
        /// <summary>
        /// report id
        /// </summary>
        public int ReportId { get; set; }

        /// <summary>
        /// list photo input
        /// </summary>
        public ICollection<string> Url { get; set; }
    }
}
