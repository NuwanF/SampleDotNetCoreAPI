using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.DomainModels
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }

    }
}
