using System;
using System.Collections.Generic;

#nullable disable

namespace HeartToHeartNon_Profit.Models.Data
{
    public partial class User
    {
        public User()
        {
            CampaignManagers = new HashSet<CampaignManager>();
            CampaignMembers = new HashSet<CampaignMember>();
            Campaigns = new HashSet<Campaign>();
            Reports = new HashSet<Report>();
            TaskDetails = new HashSet<TaskDetail>();
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
        public string CredentialFrontUrl { get; set; }
        public string CredentialBackUrl { get; set; }

        public virtual ICollection<CampaignManager> CampaignManagers { get; set; }
        public virtual ICollection<CampaignMember> CampaignMembers { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<TaskDetail> TaskDetails { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
