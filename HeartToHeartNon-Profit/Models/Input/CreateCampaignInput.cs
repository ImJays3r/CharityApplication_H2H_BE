using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class CreateCampaignInput
    {
        /// <summary>
        /// Campaign Title
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string Title { get; set; }

        /// <summary>
        /// type of campaign has 2 type long term(over a year) and short term(less than a year)
        /// </summary>
        [Required(ErrorMessage = "Can't be empty"), RegularExpression("LONGTERM|SHORTTERM", ErrorMessage = "'LONGTERM' or 'SHORTTERM'.")]
        public string Type { get; set; }

        /// <summary>
        /// Budget of campaign
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public decimal Budget { get; set; }

        /// <summary>
        /// A few information about campaign (can be null)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Location that campaign want to help
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string Location { get; set; }


        /// <summary>
        /// Id of admin who create campaign
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public int AdminId { get; set; }

        /// <summary>
        /// startdate of campaign
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public String StartDate { get; set; }

        /// <summary>
        /// enddate of campaign
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public String EndDate { get; set; }
    }
}
