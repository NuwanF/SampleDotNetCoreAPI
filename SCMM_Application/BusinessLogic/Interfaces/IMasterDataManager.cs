using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic.Interfaces
{
    public interface IMasterDataManager
    {
        public List<UserRoleDto> GetAllUserRoles();

        public List<StrokeDto> GetAllStrokes();
    }
}
