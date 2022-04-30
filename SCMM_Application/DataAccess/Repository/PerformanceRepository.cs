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
    public class PerformanceRepository : IPerformanceRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;
        public PerformanceRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<PerformanceDto> GetAll()
        {
            var result = context.Performances
                .Include(r => r.User)
                .Include(r => r.Stage)
                .Include(r => r.Stroke);

            if (result == null)
                return null;

            List<PerformanceDto> performanceDtoList = new List<PerformanceDto>();
            foreach (var performance in result)
            {
                PerformanceDto performanceDto = new PerformanceDto()
                {
                    PerformanceId = performance.PerformanceId,
                    StrokeId = performance.StrokeId,
                    StrokeName = performance.Stroke.Name,
                    StageId = performance.StageId,
                    StageName = performance.Stage.Name,
                    UserId = performance.UserId,
                    UserName = performance.User.Name,
                    PersonalBestTime = performance.PersonalBestTime
                };
                performanceDtoList.Add(performanceDto);
            }
            return performanceDtoList;
        }

        public PerformanceDto GetByUsrId(int userId)
        {
            var result = context.Performances
                .Include(r => r.User)
                .Include(r => r.Stage)
                .Include(r => r.Stroke)
                .FirstOrDefault(x => x.UserId == userId);

            if (result == null)
                return null;

            PerformanceDto performanceDto = new PerformanceDto()
            {
                PerformanceId = result.PerformanceId,
                StrokeId = result.StrokeId,
                StrokeName = result.Stroke.Name,
                StageId = result.StageId,
                StageName = result.Stage.Name,
                UserId = result.UserId,
                UserName = result.User.Name,
                PersonalBestTime = result.PersonalBestTime
            };
            return performanceDto;
        }
    }
}
