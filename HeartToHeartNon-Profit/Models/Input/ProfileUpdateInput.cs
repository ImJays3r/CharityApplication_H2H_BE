using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class ProfileUpdateInput
    {
        /// <summary>
        /// email
        /// </summary>
        [Required(ErrorMessage = "Can't be empty"), EmailAddress(ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        /// <summary>
        /// user name
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public string UserName { get; set; }

        /// <summary>
        /// phone
        /// </summary>
        [RegularExpression("(84|0[3|5|7|8|9])+([0-9]{8})", ErrorMessage = "Not A Real Phone number")]
        public string Phone { get; set; }

        /// <summary>
        /// date of birth
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// cccd / cmnd
        /// </summary>
        [Required(ErrorMessage = "Can't be empty"), StringLength(12, MinimumLength = 10, ErrorMessage = "Length must between 10 and 12")]
        public string CredentialId { get; set; }

        /// <summary>
        /// avatar
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// gender
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public string Gender { get; set; }
    }
}
