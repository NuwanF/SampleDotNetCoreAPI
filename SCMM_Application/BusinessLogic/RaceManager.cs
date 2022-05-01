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
    public class RaceManager : IRaceManager
    {
        internal IRaceRepository raceRepository;

        public RaceManager(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }

        public List<RaceDto> GetAll()
        {
            return raceRepository.GetAll();
        }

        public void AddRace(int userId, RaceDto raceDto)
        {
            raceRepository.AddRace(userId, raceDto);
        }

        public void UpdateRace(int userId, RaceDto raceDto)
        {
            raceRepository.UpdateRace(userId, raceDto);
        }

        public void DeleteRace(int raceId)
        {
            raceRepository.DeleteRace(raceId);
        }
    }
}
