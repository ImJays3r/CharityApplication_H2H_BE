using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeartToHeartNon_Profit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignManageController : ControllerBase
    {
        private readonly ICampaignManageRepository _repo;
        public CampaignManageController(ICampaignManageRepository repo)
        {
            _repo = repo;
            
        }

        [HttpPost("CreateCampaign")]
        public async Task<IActionResult> CreateCampaign(CreateCampaignInput camIn)
        {
            if (await _repo.CreateCampaign(camIn))
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
