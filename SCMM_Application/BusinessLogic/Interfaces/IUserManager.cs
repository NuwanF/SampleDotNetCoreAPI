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

        public UserDto GetById(int userId);

        public UserDto GetByCredentials(string username, string password);

        public void AddUser(UserDto userDto);

        public void UpdateUser(UserDto userDto);

        public void DeleteUser(int userId);
    }
}
