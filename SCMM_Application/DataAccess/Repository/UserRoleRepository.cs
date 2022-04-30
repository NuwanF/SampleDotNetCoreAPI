using Microsoft.EntityFrameworkCore;
using SCMM_Application.DataAccess;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;

        public UserRoleRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<UserRoleDto> GetAll()
        {
            var result = unitOfWork.UserRoles.GetAll();

            if (result == null)
                return null;

            List<UserRoleDto> userRoleDtoList = new List<UserRoleDto>();
            foreach (var userRole in result)
            {
                UserRoleDto userRoleDto = new UserRoleDto()
                {
                    UserRoleId = userRole.UserRoleId,
                    Name = userRole.Name
                };
                userRoleDtoList.Add(userRoleDto);
            }
            return userRoleDtoList;
        }

    }
}
