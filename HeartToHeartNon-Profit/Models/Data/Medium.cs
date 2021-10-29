using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class Medium
    {
        public int MediaId { get; set; }
        public int PostId { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public virtual Post Post { get; set; }
    }
}
