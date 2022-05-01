using SCMM_Application.BusinessLogic.Interfaces;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic
{
    public class UserManager: IUserManager
    {
        internal IUserRoleRepository userRoleRepository;
        internal IUserRepository userRepository;

        public UserManager(IUserRoleRepository userRoleRepository, IUserRepository userRepository)
        {
            this.userRoleRepository = userRoleRepository;
            this.userRepository = userRepository;
        }

        public List<UserDto> GetAll()
        {
            return userRepository.GetAll();
        }
        public List<UserRoleDto> GetAllUserRoles()
        {
            return userRoleRepository.GetAll();
        }

        public UserDto GetByCredentials(string username, string password)
        {
            return userRepository.GetByCredentials(username, password);
        }

        public void AddUser(UserDto userDto)
        {
            userRepository.AddUser(userDto);
        }

        public void UpdateUser(UserDto userDto)
        {
            userRepository.UpdateUser(userDto);
        }

        public void DeleteUser(int userId)
        {
            userRepository.DeleteUser(userId);
        }
    }
}
