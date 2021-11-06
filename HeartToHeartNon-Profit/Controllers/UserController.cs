using AutoMapper;
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
{   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public UserController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        /// <summary>
        /// get user detail profile
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _repo.GetUserProfile(userId);
            if (user == null)
                return NotFound();
            var resultUser = _mapper.Map<ProfileOutput>(user);
            return Ok(resultUser);
        }

        /// <summary>
        /// Update User Avatar
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateUserProfile(ProfileUpdateInput input)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            int check = await _repo.UpdateUserProfile(userId, input);
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

        /// <summary>
        /// Update User Avatar
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("apply-admin")]
        public async Task<IActionResult> ApplyToAdminCampaign(ApplyAdminInput input)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            int check = await _repo.ApplyToCampaignAdmin(userId, input);
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
