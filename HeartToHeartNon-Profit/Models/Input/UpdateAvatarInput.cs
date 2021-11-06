using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class UpdateAvatarInput
    {
        /// <summary>
        /// userId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// avatar
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
