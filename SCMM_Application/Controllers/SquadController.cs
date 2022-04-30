using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCMM_Application.BusinessLogic.Interfaces;
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
        [AuthorizeByRole("Admin")]
        public IActionResult GetAll()
        {
            var result = squadManager.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByCoach")]
        [AuthorizeByRole("Admin")]
        public IActionResult GetByCoach(int coachId)
        {
            var result = squadManager.GetAll();
            if (result == null)
                return null;

            return Ok(result.Where(x => x.CoachId == coachId));
        }
    }
}
