using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>LoginOuput</returns>
        Task<User> Login(LoginInput user);
        /// <summary>
        /// Register new account auto set role member
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> Register(Register user);
    }
}
