using SCMM_Application.BusinessLogic.Interfaces;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic
{
    public class UserRaceManager : IUserRaceManager
    {
        internal IUserRaceRepository userRaceRepository;

        public UserRaceManager(IUserRaceRepository userRaceRepository)
        {
            this.userRaceRepository = userRaceRepository;
        }

        public List<UserRaceDto> GetAll()
        {
            return userRaceRepository.GetAll();
        }

        public void AddUserRace(int userId, UserRaceDto userRaceDto)
        {
            userRaceRepository.AddUserRace(userId, userRaceDto);
        }

        public void UpdateUserRace(int userId, UserRaceDto userRaceDto)
        {
            userRaceRepository.UpdateUserRace(userId, userRaceDto);
        }

        public void DeleteUserRace(int userId, int raceId)
        {
            userRaceRepository.DeleteUserRace(userId, raceId);
        }

    }
}
