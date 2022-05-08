using SCMM_Application.BusinessLogic.Interfaces;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic
{
    public class MasterDataManager : IMasterDataManager
    {
        internal IMasterDataRepository masterDataRepository;

        public MasterDataManager(IMasterDataRepository masterDataRepository)
        {
            this.masterDataRepository = masterDataRepository;
        }
        public List<UserRoleDto> GetAllUserRoles()
        {
            return masterDataRepository.GetAllUserRoles();
        }

        public List<StrokeDto> GetAllStrokes()
        {
            return masterDataRepository.GetAllStrokes();
        }

        public List<StageDto> GetAllStages()
        {
            return masterDataRepository.GetAllStages();
        }
    }
}
