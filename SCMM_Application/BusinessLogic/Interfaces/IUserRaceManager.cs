using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic.Interfaces
{
    public interface IUserRaceManager
    {
        public List<UserRaceDto> GetAll();

        public void AddUserRace(int userId, UserRaceDto userRaceDto);

        public void UpdateUserRace(int userId, UserRaceDto userRaceDto);

        public void DeleteUserRace(int userRaceId);

    }
}
