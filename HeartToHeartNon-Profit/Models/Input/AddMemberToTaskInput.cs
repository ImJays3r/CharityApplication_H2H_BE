using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class AddMemberToTaskInput
    {
        /// <summary>
        /// task id
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// list member to add to task
        /// </summary>
        public ICollection<int> MemberId { get; set; }
    }
}
