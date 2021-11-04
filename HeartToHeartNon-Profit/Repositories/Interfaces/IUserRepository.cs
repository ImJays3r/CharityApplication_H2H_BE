using HeartToHeartNon_Profit.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// get user profile
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUserProfile(int userId);
    }
}
