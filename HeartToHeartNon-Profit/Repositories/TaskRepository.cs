using HeartToHeartNon_Profit.Models.Data;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private const string Format = "dd-MM-yyyy";
        private readonly HeartToHeartContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public TaskRepository(HeartToHeartContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create New Task
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
            public async Task<bool> CreateTask(CreateTaskInput input, int managerid)
        {
            Models.Data.Task task = new()
            {
               ManagerId = managerid,
               Title = input.Title,
               TaskType = input.TaskType,
               Description = input.Description,
               StartDate = DateTime.ParseExact(input.StartDate, Format, CultureInfo.InvariantCulture),
               EndDate = DateTime.ParseExact(input.EndDate, Format, CultureInfo.InvariantCulture),
               CampaignId = input.CampaignId,
               Status = true
            };
            await _context.Tasks.AddAsync(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
