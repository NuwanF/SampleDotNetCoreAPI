using SCMM_Application.BusinessLogic.Interfaces;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.BusinessLogic
{
    public class PerformanceManager : IPerformanceManager
    {
        internal IPerformanceRepository performanceRepository;

        public PerformanceManager(IPerformanceRepository performanceRepository)
        {
            this.performanceRepository = performanceRepository;
        }

        public List<PerformanceDto> GetAll()
        {
            return performanceRepository.GetAll();
        }
        public PerformanceDto GetByUsrId(int userId)
        {
            return performanceRepository.GetByUsrId(userId);
        }

        public void AddPerformance(int userId, PerformanceDto performanceDto)
        {
            performanceRepository.AddPerformance(userId, performanceDto);
        }

        public void UpdatePerformance(int userId, PerformanceDto performanceDto)
        {
            performanceRepository.UpdatePerformance(userId, performanceDto);
        }

        public void DeletePerformance(int performanceId)
        {
            performanceRepository.DeletePerformance(performanceId);
        }
    }
}
