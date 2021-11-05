using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class Medium
    {
        public int MediaId { get; set; }
        public int ReportId { get; set; }
        public string Url { get; set; }

        public virtual Report Report { get; set; }
    }
}
