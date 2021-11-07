using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class CreateTaskInput
    {

        /// <summary>
        /// task title
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string Title { get; set; }

        /// <summary>
        /// task type
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL"), RegularExpression("COLLECT|BUY|DELIVER", ErrorMessage = "'COLLECT' or 'BUY' or 'DELIVER'.")]
        public string TaskType { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// start day
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string StartDate { get; set; }

        /// <summary>
        /// end day
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string EndDate { get; set; }

        /// <summary>
        /// task belong to campaign id
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public int CampaignId { get; set; }
    }
}
