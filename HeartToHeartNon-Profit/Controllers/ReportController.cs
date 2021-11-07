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

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="tokenService"></param>
        public ReportController(IReportRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
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
            int id = await _repo.CreateReport(Input,memberId);
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
    }
}
