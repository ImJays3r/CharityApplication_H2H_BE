using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class LoginInput
    {
        /// <summary>
        /// email
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL"), EmailAddress(ErrorMessage = "Wrong email format")]
        public string Email { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required(ErrorMessage = "Can't be NULL")]
        public string Password { get; set; }
    }
}
