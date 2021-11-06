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
        
        /// <summary>
        ///  check exist email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<bool> UserExists(string email);

        /// <summary>
        /// update picture when create user
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<int> UpdateUserPicture(UpdateAvatarInput input);

        /// <summary>
        /// Login To ADMIN PAGE
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> LoginAdmin(LoginInput user);

    }
}
