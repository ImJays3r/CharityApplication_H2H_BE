using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListTask
    {
        /// <summary>
        /// task Id
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// manager id 
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// tasktype
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// start date
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// end date
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public bool Status { get; set; }
    }
}
