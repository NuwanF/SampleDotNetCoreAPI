using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic.Interfaces
{
    public interface IRaceManager
    {
        public List<RaceDto> GetAll();

        public void AddRace(int userId, RaceDto raceDto);

        public void UpdateRace(int userId, RaceDto raceDto);

        public void DeleteRace(int raceId);
    }
}
