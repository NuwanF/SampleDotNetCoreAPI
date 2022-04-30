using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.DomainModels
{
    public class PerformanceDto
    {
        public int PerformanceId { get; set; }

        public int StrokeId { get; set; }

        public string StrokeName { get; set; }

        public int StageId { get; set; }

        public string StageName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public decimal PersonalBestTime { get; set; }
    }
}
