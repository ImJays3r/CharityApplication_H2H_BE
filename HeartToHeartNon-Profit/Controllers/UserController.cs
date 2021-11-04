using AutoMapper;
using HeartToHeartNon_Profit.Models.Output;
using HeartToHeartNon_Profit.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUserProfile(id);
            if (user == null)
                return NotFound();
            var resultUser = _mapper.Map<ProfileOutput>(user);
            return Ok(resultUser);
        }
    }
}
