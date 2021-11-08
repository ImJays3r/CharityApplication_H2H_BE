using AutoMapper;
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
        private readonly ICampaignRepository _repoCam;
        private readonly ITokenService _tokenService;
        private const string FormatDate = "dd-MM-yyyy";
        private readonly IMapper _mapper;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="tokenService"></param>
        public TaskController(ITaskRepository repo, ITokenService tokenService, ICampaignRepository repoCam, IMapper mapper)
        {
            _repo = repo;
            _tokenService = tokenService;
            _repoCam = repoCam;
            _mapper = mapper;
        }

        /// <summary>
        /// Create New Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [Authorize(Roles = "MANAGER,ADMANAGER")]
        [HttpPost("create-task")]
        public async Task<IActionResult> CreateTask(CreateTaskInput input)
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
        /// get task detail
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

        /// <summary>
        /// get list all task
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-list-all-task")]
        public async Task<IActionResult> GetListAllTask(int campaignId)
        {
                var taskList = await _repoCam.GetListTask(campaignId);
                var resultList = _mapper.Map<IEnumerable<ListTask>>(taskList);
                return Ok(resultList);

        }

        /// <summary>
        /// get list my task 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-my-list-task")]
        public async Task<IActionResult> GetMyListTask(int campaignId)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            string Role = User.FindFirst(ClaimTypes.Role).Value.ToString();

            if(Role == "MANAGER" || Role == "ADMANAGER")
            {
                var taskList = await _repo.GetListTaskManager(campaignId,userId);
                var resultList = _mapper.Map<IEnumerable<ListTask>>(taskList);
                return Ok(resultList);
            } 
            else if (Role == "MEMBER" || Role == "ADMEMBER")
            {
                var taskList = await _repo.GetListTaskMember(campaignId,userId);
                var resultList = _mapper.Map<IEnumerable<ListTask>>(taskList);
                return Ok(resultList);
            }

            return NoContent();

        }

        /// <summary>
        /// get campaign list member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("campaign-list-member/{id}")]
        public async Task<IActionResult> GetCampaignListMember(int id)
        {
            var listMember = await _repoCam.GetListMember(id);
            

            ListParticipant result = new()
            {
                listMember = (ICollection<ListUserOutput>)_mapper.Map<IEnumerable<ListUserOutput>>(listMember)
            };

            return Ok(result);
        }

        /// <summary>
        /// Add list member to task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [Authorize(Roles = "MANAGER,ADMANAGER")]
        [HttpPost("Add-member-to-task")]
        public async Task<IActionResult> AddListMemberToTask(AddMemberToTaskInput input)
        {
            int managerid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (await _repo.AddMemberToTask(input))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        
    }
}
