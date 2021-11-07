using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class ApplyAdminInput
    {
        /// <summary>
        /// front pic of cccd
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string CredentialFrontUrl { get; set; }

        /// <summary>
        /// back pic of cccd
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string CredentialBackUrl { get; set; }
    }
}
