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
    public class PerformanceController : ControllerBase
    {

        private readonly ILogger<PerformanceController> logger;

        internal IPerformanceManager performanceManager;

        public PerformanceController(ILogger<PerformanceController> logger, IPerformanceManager performanceManager)
        {
            this.logger = logger;
            this.performanceManager = performanceManager;
        }

        [HttpGet]
        [Route("GetAllPerformance")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var result = performanceManager.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetPerformanceByUser")]
        [AllowAnonymous]
        public IActionResult GetByUserId(int userId)
        {
            var result = performanceManager.GetByUsrId(userId);
            return Ok(result);
        }
    }
}
