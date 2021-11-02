﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Models.Input
{
    public class Register
    {   /// <summary>
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
        /// user's  birthday 
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public DateTime DateOfBirth { get; set; }


        /// <summary>
        /// password
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public string Password { get; set; }

        /// <summary>
        /// confirm password
        /// </summary>
        [Required(ErrorMessage = "Can't be empty"), Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// cmnd/cccd
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public string CredentialId { get; set; }

        /// <summary>
        /// gender
        /// </summary>
        [Required(ErrorMessage = "Can't be empty")]
        public string Gender { get; set; }
    }
}