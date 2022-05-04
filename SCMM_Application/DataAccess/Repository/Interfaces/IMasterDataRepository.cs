using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository.Interfaces
{
    public interface IMasterDataRepository
    {
        public List<UserRoleDto> GetAllUserRoles();

        public List<StrokeDto> GetAllStrokes();
    }
}
