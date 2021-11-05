using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class User
    {
        public User()
        {
            Campaigns = new HashSet<Campaign>();
            Reports = new HashSet<Report>();
            Tasks = new HashSet<Task>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RoleName { get; set; }
        public DateTime SignUpDate { get; set; }
        public string CredentialId { get; set; }
        public bool Status { get; set; }
        public string AvatarUrl { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
