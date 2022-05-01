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

        internal IRaceManager raceManager;

        public RaceController(ILogger<RaceController> logger, IRaceManager raceManager)
        {
            this.logger = logger;
            this.raceManager = raceManager;
        }

        [HttpGet]
        [Route("GetAllRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult GetAll()
        {
            var result = raceManager.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("PostRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult PostRace(int userId, [FromBody] RaceDto raceDto)
        {
            raceManager.AddRace(userId, raceDto);
            return Ok();
        }

        [HttpPut]
        [Route("PutRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult PutRace(int userId, [FromBody] RaceDto raceDto)
        {
            raceManager.UpdateRace(userId, raceDto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteRace")]
        [AuthorizeByRole("Admin")]
        public IActionResult DeleteRace(int raceId)
        {
            raceManager.DeleteRace(raceId);
            return Ok();
        }
    }
}
