using Microsoft.AspNetCore.Authorization;
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
    }
}
