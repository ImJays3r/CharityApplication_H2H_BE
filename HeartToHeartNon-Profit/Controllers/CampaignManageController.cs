using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HeartToHeartNon_Profit.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignManageController : ControllerBase
    {
        private readonly ICampaignManageRepository _repo;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        public CampaignManageController(ICampaignManageRepository repo)
        {
            _repo = repo;
            
        }

        /// <summary>
        /// Create new campaign
        /// </summary>
        /// <param name="camIn"></param>
        /// <returns></returns>
       
        [HttpPost("CreateCampaign")]
        public async Task<IActionResult> CreateCampaign(CreateCampaignInput camIn)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            int id = await _repo.CreateCampaign(camIn);
            if (id > 0)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update-picture")]
        public async Task<IActionResult> UpdateCamPicture(String url, int id)
        {
         

            int check = await _repo.UpdateCamPicture(url, id);
            if (check == 2)
            {
                return Unauthorized();
            }
            else if (check == 1)
            {
                return Ok();
            }
            else if (check == 3)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
