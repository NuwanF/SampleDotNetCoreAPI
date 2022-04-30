using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.DomainModels
{
    public class SquadDto
    {
        public int SquadId { get; set; }

        public string Name { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int CoachId { get; set; }

        public string CoachName { get; set; }
    }
}
