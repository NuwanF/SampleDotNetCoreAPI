using SCMM_Application.DataAccess.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic.Interfaces
{
    public interface ISquadManager
    {
        public List<SquadDto> GetAll();

        public void AddSquad(int userId, SquadDto squadDto);

        public void UpdateSquad(int userId, SquadDto squadDto);

        public void DeleteSquad(int squadId);
    }
}
