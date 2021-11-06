using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ListUserOutput
    {
        /// <summary>
        /// user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// role 
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// avatar
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// phone
        /// </summary>
        public string Phone { get; set; }
    }
}
