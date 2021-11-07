using HeartToHeartNon_Profit.Interfaces;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Models.Output;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repo;
        private readonly ITokenService _tokenService;
        private const string FormatDate = "dd-MM-yyyy";

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="tokenService"></param>
        public TaskController(ITaskRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Register to a member role
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [Authorize(Roles = "MANAGER,ADMANAGER")]
        [HttpPost("create-task")]
        public async Task<IActionResult> Register(CreateTaskInput input)
        {
            int managerid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (await _repo.CreateTask(input,managerid))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get campaign detail
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("task-detail/{id}")]
        public async Task<IActionResult> GetTaskDetail(int id)
        {
            var taskDetail = await _repo.GetTaskDetail(id);
            TaskDetailOutput result = new()
            {
                TaskId = id,
                Title = taskDetail.Title,
                CampaignId = taskDetail.CampaignId,
                Description = taskDetail.Description,
                StartDate = taskDetail.StartDate.ToString(FormatDate),
                EndDate = taskDetail.EndDate.ToString(FormatDate),
                ManagerId = taskDetail.ManagerId,
                Status = taskDetail.Status,
                TaskType = taskDetail.TaskType
                
            };

            return Ok(result);
        }
    }
}
