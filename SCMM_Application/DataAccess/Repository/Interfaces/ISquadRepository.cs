using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository.Interfaces
{
    public interface ISquadRepository
    {
        public List<SquadDto> GetAll();

        public void AddSquad(int userId, SquadDto squadDto);

        public void UpdateSquad(int userId, SquadDto squadDto);

        public void DeleteSquad(int squadId);
    }
}
