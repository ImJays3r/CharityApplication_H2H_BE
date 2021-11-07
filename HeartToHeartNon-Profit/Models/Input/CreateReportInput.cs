using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class CreateReportInput
    {
        /// <summary>
        /// task id
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public int TaskId { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// price 
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public decimal Value { get; set; }
    }
}
