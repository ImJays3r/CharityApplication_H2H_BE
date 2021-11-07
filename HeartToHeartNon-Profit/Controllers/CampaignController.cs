using AutoMapper;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public CampaignController(ICampaignRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// get list campaign 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetCampaigns()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            String Role = User.FindFirst(ClaimTypes.Role).Value.ToString();
            if (Role == "ADMIN")
            {
                var campaigns = await _repo.GetListCampaign(userId);
                var resultList = _mapper.Map<IEnumerable<ListCampaign>>(campaigns);
                return Ok(resultList);
            }
            else if (Role == "MANAGER" || Role == "ADMANAGER")
            {
                var campaigns = await _repo.GetListCampaignManager(userId);
                var resultList = _mapper.Map<IEnumerable<ListCampaign>>(campaigns);
                return Ok(resultList);
            }
            else if (Role == "MEMBER" || Role == "ADMEMBER")
            {
                var campaigns = await _repo.GetListCampaignMember(userId);
                var resultList = _mapper.Map<IEnumerable<ListCampaign>>(campaigns);
                return Ok(resultList);
            }

            return NoContent();

        }

        /// <summary>
        /// get campaign detail
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>

        [HttpGet("campaign-detail/{id}")]
        public async Task<IActionResult> GetCampaignDetail(int id)
        {
            var campaign = await _repo.GetCampaignDetail(id);
            int totalPar = await _repo.GetTotalParticipant(id);
            int totalTask = await _repo.GetTotalTask(id);
            var TaskList = await _repo.GetListTask(id);
            int TotalReport = await _repo.GetTotalReport(TaskList);

            CampaignDetailOutput result = new()
            {
                CampaignId = campaign.CampaignId,
                Title = campaign.Title,
                Type = campaign.Type,
                AdminId = campaign.AdminId,
                Budget = campaign.Budget,
                CreateDate = campaign.CreateDate.ToString("dd-MM-yyyy"),
                Description = campaign.Description,
                EndDate = campaign.EndDate.ToString("dd-MM-yyyy"),
                Location = campaign.Location,
                Photourl = campaign.Photourl,
                StartDate = campaign.StartDate.ToString("dd-MM-yyyy"),
                Status = campaign.Status,
                totalParticipant = totalPar,
                totalReport = TotalReport,
                totalTask = totalTask
            };

            return Ok(result);
        }

        /// <summary>
        /// get campaign list participant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("campaign-list-participant/{id}")]
        public async Task<IActionResult> GetCampaignListParticipant(int id)
        {
            var listMember = await _repo.GetListMember(id);
            var listManager = await _repo.GetListManager(id);
            var resultAdminInfor = await _repo.GetAdminForList(id);

            ListParticipant result = new()
            {
                listMember = (ICollection<ListUserOutput>)_mapper.Map<IEnumerable<ListUserOutput>>(listMember),
                listManager = (ICollection<ListUserOutput>)_mapper.Map<IEnumerable<ListUserOutput>>(listManager),
                admin = _mapper.Map<ListUserOutput>(resultAdminInfor)
            };

            return Ok(result);
        }
    }
}
