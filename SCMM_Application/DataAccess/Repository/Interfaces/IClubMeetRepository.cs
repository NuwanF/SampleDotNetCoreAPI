using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository.Interfaces
{
    public interface IClubMeetRepository
    {
        public List<ClubMeetDto> GetAll();

        public void AddClubMeet(int userId, ClubMeetDto clubMeetDto);

        public void UpdateClubMeet(int userId, ClubMeetDto clubMeetDto);

        public void DeleteClubMeet(int clubMeetId);

    }
}
