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
    public class MasterDataController : ControllerBase
    {

        private readonly ILogger<MasterDataController> logger;

        internal IMasterDataManager masterDadtaManager;

        public MasterDataController(ILogger<MasterDataController> logger, IMasterDataManager masterDataManager)
        {
            this.logger = logger;
            this.masterDadtaManager = masterDataManager;
        }

        [HttpGet]
        [Route("GetAllUserRoles")]
        [AllowAnonymous]
        public IActionResult GetAllUserRoles()
        {
            var result = masterDadtaManager.GetAllUserRoles();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllStrokes")]
        [AllowAnonymous]
        public IActionResult GetAllStrokes()
        {
            var result = masterDadtaManager.GetAllStrokes();
            return Ok(result);
        }


    }
}
