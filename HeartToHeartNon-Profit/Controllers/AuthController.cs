using HeartToHeartNon_Profit.Interfaces;
using HeartToHeartNon_Profit.Models.Input;
using HeartToHeartNon_Profit.Models.Output;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="tokenService"></param>
        public AuthController(IAuthRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Login With Email And Password
        /// </summary>
        /// <param name="userIn"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInput userIn)
        {
            var user = await _repo.Login(userIn);

            if (user == null)
                return Unauthorized();

            LoginOutput login = new()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
            return Ok(login);
        }


        /// <summary>
        /// Login to Admin Page
        /// </summary>
        /// <param name="userIn"></param>
        /// <returns></returns>
        [HttpPost("login-admin")]
        public async Task<IActionResult> LoginAdmin(LoginInput userIn)
        {
            var user = await _repo.LoginAdmin(userIn);

            if (user == null)
                return Unauthorized();

            LoginOutput login = new()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
            return Ok(login);
        }

        /// <summary>
        /// Register to a member role
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register user)
        {
            if (await _repo.UserExists(user.Email))
                return BadRequest("Email already exists");
            if (await _repo.Register(user))
            {
                return Ok();
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
        [HttpPut("update-avatar")]
        public async Task<IActionResult> UpdateUserPicture(UpdateAvatarInput input)
        {

            int check = await _repo.UpdateUserPicture(input);
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
