using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class LoginOutput
    {
        /// <summary>
        /// userid
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// token having : role , id, email
        /// </summary>
        public string Token { get; set; }
    }
}
