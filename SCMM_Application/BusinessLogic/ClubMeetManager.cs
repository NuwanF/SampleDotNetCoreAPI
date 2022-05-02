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
    public class ClubMeetManager : IClubMeetManager
    {
        internal IClubMeetRepository clubMeetRepository;

        public ClubMeetManager(IClubMeetRepository clubMeetRepository)
        {
            this.clubMeetRepository = clubMeetRepository;
        }

        public List<ClubMeetDto> GetAll()
        {
            return clubMeetRepository.GetAll();
        }

        public void AddClubMeet(int userId, ClubMeetDto clubMeetDto)
        {
            clubMeetRepository.AddClubMeet(userId, clubMeetDto);
        }

        public void UpdateClubMeet(int userId, ClubMeetDto clubMeetDto)
        {
            clubMeetRepository.UpdateClubMeet(userId, clubMeetDto);
        }

        public void DeleteClubMeet(int clubMeetId)
        {
            clubMeetRepository.DeleteClubMeet(clubMeetId);
        }
    }
}
