using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.DomainModels
{
    public class ClubMeetDto
    {
        public int ClubMeetId { get; set; }

        public string Name { get; set; }

        public string Venue { get; set; }

        public DateTime MeetDate { get; set; }
    }
}
