using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SCMM_Application.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeByRoleAttribute : Attribute, IAuthorizationFilter
    {

        readonly string role;
        public AuthorizeByRoleAttribute(string role)
        {
            this.role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var authorize = context.HttpContext.User.Claims.Any(c => c.Type == "Role" && c.Value == role);
            bool authorize = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value == role;
            if (!authorize)
            {
                context.Result = new ForbidResult();
            }

            //var account = (Account)context.HttpContext.Items["Account"];
            //if (true)
            //{
            //    // not logged in
            //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //}
        }
    }

}
