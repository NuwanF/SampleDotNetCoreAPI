using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.DomainModels
{
    public class RaceDto
    {
        public int RaceId { get; set; }

        public string Name { get; set; }

        public int ClubMeetId { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }

        public int Distance { get; set; }

        public int StrokeId { get; set; }

        public string StrokeName { get; set; }

        public string Venue { get; set; }

        public DateTime MeetDate { get; set; }
    }
}
