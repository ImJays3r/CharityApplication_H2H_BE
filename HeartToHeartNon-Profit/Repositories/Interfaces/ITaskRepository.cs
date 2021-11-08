using HeartToHeartNon_Profit.Models.Data;
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
        /// Create New task
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<bool> CreateTask(CreateTaskInput input, int managerid);

        /// <summary>
        /// Get Task Detail
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<Models.Data.Task> GetTaskById(int taskId);

        /// <summary>
        /// get list task of campaign for manager
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Data.Task>> GetListTaskManager(int campaignId, int ManagerId);

        /// <summary>
        /// get list task of campaign for member
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TaskDetail>> GetListTaskMember(int campaignId, int MemberId);

        /// <summary>
        /// Add members to task
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<bool> AddMemberToTask(AddMemberToTaskInput input);

        /// <summary>
        /// get list task detail
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TaskDetail>> GetListMemberInTask(int taskId);
    }
}
