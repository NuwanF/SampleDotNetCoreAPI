﻿using Microsoft.AspNetCore.Mvc;
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
    public class SquadController : ControllerBase
    {
        private readonly ILogger<SquadController> logger;

        internal ISquadManager squadManager;

        public SquadController(ILogger<SquadController> logger, ISquadManager squadManager)
        {
            this.logger = logger;
            this.squadManager = squadManager;
        }

        [HttpGet]
        [Route("GetAllSquad")]
        [AuthorizeByRole("Coach")]
        public IActionResult GetAll()
        {
            var result = squadManager.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByCoach")]
        [AuthorizeByRole("Coach")]
        public IActionResult GetByCoach(int coachId)
        {
            var result = squadManager.GetAll();
            if (result == null)
                return null;

            return Ok(result.Where(x => x.CoachId == coachId));
        }

        [HttpPost]
        [Route("PostSquad")]
        [AuthorizeByRole("Coach")]
        public IActionResult PostSquad(int userId, [FromBody] SquadDto squadDto)
        {
            squadManager.AddSquad(userId, squadDto);
            return Ok();
        }

        [HttpPut]
        [Route("PutSquad")]
        [AuthorizeByRole("Coach")]
        public IActionResult PutSquad(int userId, [FromBody] SquadDto squadDto)
        {
            squadManager.UpdateSquad(userId, squadDto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteSquad")]
        [AuthorizeByRole("Coach")]
        public IActionResult DeleteSquad(int squadId)
        {
            squadManager.DeleteSquad(squadId);
            return Ok();
        }
    }
}
