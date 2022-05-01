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
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> logger;

        internal IUserManager userManager;

        public UserController(ILogger<UserController> logger, IUserManager userManager)
        {
            this.logger = logger;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("GetUserRole")]
        public IActionResult GetUserRoles()
        {
            var result = userManager.GetAllUserRoles();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        [AuthorizeByRole("Admin")]
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

        [HttpPost]
        [Route("PostUser")]
        public IActionResult PostUser([FromBody] UserDto userDto)
        {
            userManager.AddUser(userDto);
            return Ok();
        }

        [HttpPut]
        [Route("PutUser")]
        public IActionResult PutUser([FromBody] UserDto userDto)
        {
            userManager.UpdateUser(userDto);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            userManager.DeleteUser(userId);
            return Ok();
        }
    }
}
