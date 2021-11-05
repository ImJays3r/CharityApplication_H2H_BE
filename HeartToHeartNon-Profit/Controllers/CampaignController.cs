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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCampaigns()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var campaigns = await _repo.GetListCampaign(userId);
            var resultList = _mapper.Map<IEnumerable<ListCampaign>>(campaigns);
            return Ok(resultList);
        }
    }
}
