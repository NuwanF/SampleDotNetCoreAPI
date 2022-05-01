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
    public class RaceController : ControllerBase
    {

        private readonly ILogger<RaceController> logger;

        internal IUserRaceManager userRaceManager;

        public RaceController(ILogger<RaceController> logger, IUserRaceManager userRaceManager)
        {
            this.logger = logger;
            this.userRaceManager = userRaceManager;
        }

        [HttpGet]
        [Route("GetAllRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult GetAll()
        {
            var result = userRaceManager.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("PostUserRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult PostUserRace(int userId, [FromBody] UserRaceDto userRaceDto)
        {
            userRaceManager.AddUserRace(userId, userRaceDto);
            return Ok();
        }

        [HttpPut]
        [Route("PutUserRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult PutUserRace(int userId, [FromBody] UserRaceDto userRaceDto)
        {
            userRaceManager.UpdateUserRace(userId, userRaceDto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUserRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult DeleteUserRace(int userRaceId)
        {
            userRaceManager.DeleteUserRace(userRaceId);
            return Ok();
        }
    }
}
