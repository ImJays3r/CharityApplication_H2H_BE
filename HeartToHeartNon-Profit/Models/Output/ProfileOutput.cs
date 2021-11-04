using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Output
{
    public class ProfileOutput
    {
        /// <summary>
        /// user Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// user email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// user phone num
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// role name of user
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// cmnd cccd
        /// </summary>
        public string CredentialId { get; set; }

        /// <summary>
        /// avater picture
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// gender
        /// </summary>
        public string Gender { get; set; }
    }
}
