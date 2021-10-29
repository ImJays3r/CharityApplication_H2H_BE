using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class Post
    {
        public Post()
        {
            Media = new HashSet<Medium>();
        }

        public int PostId { get; set; }
        public int ReportId { get; set; }
        public string Tittle { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }

        public virtual Report Report { get; set; }
        public virtual ICollection<Medium> Media { get; set; }
    }
}
