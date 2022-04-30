using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository.Interfaces
{
    public interface IUserRepository
    {
        public List<UserDto> GetAll();
        public UserDto GetByCredentials(string username, string password);

    }
}
