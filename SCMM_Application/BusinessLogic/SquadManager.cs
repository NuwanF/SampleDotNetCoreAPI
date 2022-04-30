using SCMM_Application.BusinessLogic.Interfaces;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic
{
    public class SquadManager: ISquadManager
    {
        internal ISquadRepository squadRepository;

        public SquadManager(ISquadRepository squadRepository)
        {
            this.squadRepository = squadRepository;
        }
        public List<SquadDto> GetAll()
        {
            return squadRepository.GetAll();
        }
    }
}
