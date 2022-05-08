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
    public class MasterDataRepository: IMasterDataRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;

        public MasterDataRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<UserRoleDto> GetAllUserRoles()
        {
            try
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
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            
        }

        public List<StrokeDto> GetAllStrokes()
        {
            try
            {
                var result = unitOfWork.Strokes.GetAll();

                if (result == null)
                    return null;

                List<StrokeDto> strokeDtoList = new List<StrokeDto>();
                foreach (var stroke in result)
                {
                    StrokeDto strokeDto = new StrokeDto()
                    {
                        StrokeId = stroke.StrokeId,
                        Name = stroke.Name
                    };
                    strokeDtoList.Add(strokeDto);
                }
                return strokeDtoList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public List<StageDto> GetAllStages()
        {
            try
            {
                var result = unitOfWork.Stages.GetAll();

                if (result == null)
                    return null;

                List<StageDto> stageDtoList = new List<StageDto>();
                foreach (var stage in result)
                {
                    StageDto stageDto = new StageDto()
                    {
                        StageId = stage.StageId,
                        Name = stage.Name
                    };
                    stageDtoList.Add(stageDto);
                }
                return stageDtoList;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
