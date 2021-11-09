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
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _repo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private const string FormatDate = "dd-MM-yyyy";

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="tokenService"></param>
        public ReportController(IReportRepository repo, ITokenService tokenService, IMapper mapper)
        {
            _repo = repo;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        /// <summary>
        /// create Report return id to add picture
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        [Authorize(Roles = "MEMBER,ADMEMBER")]
        [HttpPost("CreateReport")]
        public async Task<IActionResult> CreateReport(CreateReportInput Input)
        {
            int memberId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            int id = await _repo.CreateReport(Input, memberId);
            CreateReportOutput ReportId = new()
            {
                ReportId = id
            };
            if (id > 0)
            {
                return Ok(ReportId);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update campaign picture
        /// </summary>
        /// <param name="album report"></param>
        /// 
        /// <returns></returns>
        [Authorize(Roles = "MEMBER,ADMEMBER")]
        [HttpPost("update-album-report")]
        public async Task<IActionResult> UpdateAlbumReport(UpdatePictureReportInput Input)
        {

            if (await _repo.UpdateReportAlbum(Input))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get list all report 
        /// </summary>
        /// <param name="campaignid"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("campaign-list-all-report")]
        public async Task<IActionResult> GetAllListReport(int campaignid)
        {
            var ListReport = await _repo.GetLisAllReport(campaignid);
            var ListreportCount = ListReport.ToList();
            List<ListReportCampaign> result = new List<ListReportCampaign> { };
            foreach (var report in ListreportCount)
            {
                decimal total = 0;
                total = await _repo.GetTotalReportOfTask(report.TaskId);

                string url = await _repo.GetFirstPicReport(report.TaskId);

                ListReportCampaign EachReport = new()
                {
                    TaskId = report.TaskId,
                    Title = report.Title,
                    TaskType = report.TaskType,
                    PhotoUrl = url,
                    TotalValue = total,
                    StartDate = report.StartDate.ToString("dd-MM-yyyy"),
                    EndDate = report.EndDate.ToString("dd-MM-yyyy"),
                    Status = report.Status
                };
                result.Add(EachReport);
            }

            return Ok(result);
        }

        /// <summary>
        /// get list all report of manager
        /// </summary>
        /// <param name="campaignid"></param>
        /// <returns></returns>
        [Authorize(Roles = "MANAGER,ADMANAGER")]
        [HttpGet("campaign-list-report-manager")]
        public async Task<IActionResult> GetListReportManager(int campaignid)
        {
            int managerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var ListReport = await _repo.GetListReportManager(campaignid, managerId);
            var ListreportCount = ListReport.ToList();
            List<ListReportCampaign> result = new List<ListReportCampaign> { };
            foreach (var report in ListreportCount)
            {
                decimal total = await _repo.GetTotalReportOfTask(report.TaskId);
                string url = await _repo.GetFirstPicReport(report.TaskId);
                ListReportCampaign EachReport = new()
                {
                    TaskId = report.TaskId,
                    Title = report.Title,
                    TaskType = report.TaskType,
                    PhotoUrl = url,
                    TotalValue = total,
                    StartDate = report.StartDate.ToString("dd-MM-yyyy"),
                    EndDate = report.EndDate.ToString("dd-MM-yyyy"),
                    Status = report.Status
                };
                result.Add(EachReport);
            }

            return Ok(result);
        }

        /// <summary>
        /// get list all report of member
        /// </summary>
        /// <param name="campaignid"></param>
        /// <returns></returns>
        [Authorize(Roles = "MEMBER,ADMEMBER")]
        [HttpGet("campaign-list-report-member")]
        public async Task<IActionResult> GetListReportMember(int campaignid)
        {
            int memberId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var ListReport = await _repo.GetListReportMember(campaignid, memberId);
            var ListreportCount = ListReport.ToList();
            List<ListReportCampaign> result = new List<ListReportCampaign> { };
            foreach (var report in ListreportCount)
            {
                decimal total = await _repo.GetTotalReportOfTask(report.TaskId);
                string url = await _repo.GetFirstPicReport(report.TaskId);
                ListReportCampaign EachReport = new()
                {
                    TaskId = report.TaskId,
                    Title = report.Task.Title,
                    TaskType = report.Task.TaskType,
                    PhotoUrl = url,
                    TotalValue = total,
                    StartDate = report.Task.StartDate.ToString("dd-MM-yyyy"),
                    EndDate = report.Task.EndDate.ToString("dd-MM-yyyy"),
                    Status = report.Task.Status
                };
                result.Add(EachReport);
            }

            return Ok(result);
        }

        /// <summary>
        /// get list all report of task
        /// </summary>
        /// <param name="taskid"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-list-all-report-of-task")]
        public async Task<IActionResult> GetListReportOfTask(int taskid)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            string role = User.FindFirst(ClaimTypes.Role).Value.ToString();

            if (role != "MEMBER" && role != "ADMEMBER")
            {
                var listReport = await _repo.GetLisAllReportOfTask(taskid);
                var resultList = _mapper.Map<IEnumerable<ListReportTask>>(listReport);
                return Ok(resultList);
            } 
            else if (role == "MEMBER" || role == "ADMEMBER")
            {
                var listReport = await _repo.GetLisAllReportOfTaskByMember(taskid,userId);
                var resultList = _mapper.Map<IEnumerable<ListReportTask>>(listReport);
                return Ok(resultList);
            }

                return NoContent();
        }
    }
}
