using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class TaskDetail
    {
        public int TaskDetailld { get; set; }
        public int MemberId { get; set; }
        public int TaskId { get; set; }

        public virtual User Member { get; set; }
        public virtual Task Task { get; set; }
    }
}
