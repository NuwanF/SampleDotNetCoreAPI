using SCMM_Application.DataAccess.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic.Interfaces
{
    public interface IUserManager
    {
        public List<UserDto> GetAll();
        public List<UserRoleDto> GetAllUserRoles();
        public UserDto GetByCredentials(string username, string password);
    }
}
