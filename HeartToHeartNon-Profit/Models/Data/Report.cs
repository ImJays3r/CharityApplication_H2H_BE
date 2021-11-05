using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class Report
    {
        public Report()
        {
            Media = new HashSet<Medium>();
            Posts = new HashSet<Post>();
        }

        public int ReportId { get; set; }
        public int TaskId { get; set; }
        public int MemberId { get; set; }
        public string Description { get; set; }
        public string ReportType { get; set; }
        public decimal Value { get; set; }
        public bool Status { get; set; }

        public virtual User Member { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
