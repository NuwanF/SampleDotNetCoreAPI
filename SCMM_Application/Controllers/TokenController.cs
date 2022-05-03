using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class TokenController : Controller
    {
        private IConfiguration config;
        internal IUserManager userManager;

        public TokenController(IConfiguration config, IUserManager userManager)
        {
            this.config = config;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("GetToken")]
        public IActionResult GetToken(string username, string password)
        {
            var result = userManager.GetByCredentials(username, password);
            if (result == null)
                return Unauthorized();
            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(result);
            return Ok(token);
        }
    }
}
