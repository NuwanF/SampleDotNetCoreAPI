using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCMM_Application.BusinessLogic.Interfaces;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubMeetController : ControllerBase
    {

        private readonly ILogger<ClubMeetController> logger;

        internal IClubMeetManager clubMeetManager;

        public ClubMeetController(ILogger<ClubMeetController> logger, IClubMeetManager clubMeetManager)
        {
            this.logger = logger;
            this.clubMeetManager = clubMeetManager;
        }

        [HttpGet]
        [Route("GetAllClubMeet")]
        [AuthorizeByRole("Admin")]
        public IActionResult GetAll()
        {
            var result = clubMeetManager.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("PostClubMeet")]
        [AuthorizeByRole("Admin")]
        public IActionResult PostClubMeet(int userId, [FromBody] ClubMeetDto clubMeetDto)
        {
            clubMeetManager.AddClubMeet(userId, clubMeetDto);
            return Ok();
        }

        [HttpPut]
        [Route("PutClubMeet")]
        [AuthorizeByRole("Admin")]
        public IActionResult PutClubMeet(int userId, [FromBody] ClubMeetDto clubMeetDto)
        {
            clubMeetManager.UpdateClubMeet(userId, clubMeetDto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteClubMeet")]
        [AuthorizeByRole("Admin")]
        public IActionResult DeleteClubMeet(int clubMeetId)
        {
            clubMeetManager.DeleteClubMeet(clubMeetId);
            return Ok();
        }
    }
}
