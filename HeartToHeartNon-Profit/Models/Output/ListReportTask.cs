using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListReportTask
    {
        public int ReportId { get; set; }
        public int TaskId { get; set; }
        public int MemberId { get; set; }
        public string Description { get; set; }
        public string ReportType { get; set; }
        public decimal Value { get; set; }
        public bool Status { get; set; }
    }
}
