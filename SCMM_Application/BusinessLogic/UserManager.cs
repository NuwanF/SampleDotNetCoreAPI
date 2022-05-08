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
        internal IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserDto> GetAll()
        {
            return userRepository.GetAll();
        }

        public UserDto GetById(int userId)
        {
            return userRepository.GetById(userId);
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
