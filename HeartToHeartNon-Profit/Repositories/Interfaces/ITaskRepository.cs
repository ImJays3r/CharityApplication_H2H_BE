using HeartToHeartNon_Profit.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Register new account auto set role member
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<bool> CreateTask(CreateTaskInput input, int managerid);
        
    }
}
