using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HeartToHeartContext _context;
        private const string Format = "dd-MM-yyyy";
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(HeartToHeartContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Get user profile 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUserProfile(int userId)
        {
            var user = await _context.Users.Where(a => a.UserId == userId && a.RoleName != "SYSADMIN").FirstOrDefaultAsync();
            return user;
        }

        public async Task<int> UpdateUserProfile(int userId, ProfileUpdateInput input)
        {
            try
            {
                var user = await _context.Users.Where(a => a.UserId == userId).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Email = input.Email;
                    user.UserName = input.UserName;
                    user.Phone = input.Phone;
                    user.DateOfBirth = DateTime.ParseExact(input.DateOfBirth, Format, CultureInfo.InvariantCulture);
                    user.CredentialId = input.CredentialId;
                    user.Gender = input.Gender;
                }
                if (await _context.SaveChangesAsync() > 0)
                    return 1;
                return 3;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// apply to be campaign admin
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="front"></param>
        /// <param name="back"></param>
        /// <returns></returns>
        public async Task<int> ApplyToCampaignAdmin(int userId, ApplyAdminInput input)
        {
            try
            {
                var user = await _context.Users.Where(a => a.UserId == userId && a.RoleName != "ADMIN").FirstOrDefaultAsync();
                if (user != null)
                {
                    user.CredentialBackUrl = input.CredentialBackUrl;
                    user.CredentialFrontUrl = input.CredentialFrontUrl;
                    if(user.RoleName == "MEMBER")
                    {
                        user.RoleName = "ADMEMBER";
                    } else if (user.RoleName == "MANAGER")
                    {
                        user.RoleName = "ADMANAGER";
                    }
                }
                if (await _context.SaveChangesAsync() > 0)
                    return 1;
                return 3;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
