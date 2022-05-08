using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    [Authorize]
    public class UserController : ControllerBase
    {
        private IConfiguration config;
        private readonly ILogger<UserController> logger;
        internal IUserManager userManager;

        public UserController(IConfiguration config, ILogger<UserController> logger, IUserManager userManager)
        {
            this.config = config;
            this.logger = logger;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var result = userManager.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetStudents")]
        [AllowAnonymous]
        public IActionResult GetStudents()
        {
            var result = userManager.GetAll();
            if(result == null)
                return null;

            return Ok(result.Where(x => x.UserRoleName == "Student"));
        }

        [HttpGet]
        [Route("GetDefaultUsers")]
        [AllowAnonymous]
        public IActionResult GetDefaultUsers()
        {
            var result = userManager.GetAll();
            if (result == null)
                return null;

            return Ok(result.Where(x => x.UserRoleName == "Default"));
        }

        [HttpGet]
        [Route("GetParents")]
        [AllowAnonymous]
        public IActionResult GetParents()
        {
            var result = userManager.GetAll();
            if (result == null)
                return null;

            return Ok(result.Where(x => x.UserRoleName == "Parent"));
        }

        [HttpPost]
        [Route("PostUser")]
        [AllowAnonymous]
        public IActionResult PostUser([FromBody] UserDto userDto)
        {
            userManager.AddUser(userDto);
            var result = userManager.GetByCredentials(userDto.Username, userDto.Password);
            if (result == null)
                return Unauthorized();
            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(result);
            return Ok(token);
        }

        [HttpPut]
        [Route("PutUser")]
        [AllowAnonymous]
        public IActionResult PutUser([FromBody] UserDto userDto)
        {
            userManager.UpdateUser(userDto);
            var result = userManager.GetById(userDto.UserId);
            if (result == null)
                return Unauthorized();
            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(result);
            return Ok(token);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        [Authorize]
        public IActionResult DeleteUser(int userId)
        {
            userManager.DeleteUser(userId);
            return Ok();
        }
    }
}
