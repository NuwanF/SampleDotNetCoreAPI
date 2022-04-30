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
        private IConfiguration _config;

        internal IUserManager userManager;

        public TokenController(IConfiguration config, IUserManager userManager)
        {
            _config = config;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetToken(string username, string password)
        {
            var result = userManager.GetByCredentials(username, password);
            if (result == null)
                return Unauthorized();
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken(result);
            return Ok(token);
        }
    }
}
