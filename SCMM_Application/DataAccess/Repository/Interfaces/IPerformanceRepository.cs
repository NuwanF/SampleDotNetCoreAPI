﻿using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository.Interfaces
{
    public interface IPerformanceRepository
    {
        public List<PerformanceDto> GetAll();

        public PerformanceDto GetByUsrId(int userId);

    }
}
