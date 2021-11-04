using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HeartToHeartContext _context;

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
    }
}
