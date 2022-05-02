using Microsoft.EntityFrameworkCore;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository
{
    public class ClubMeetRepository : IClubMeetRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;
        public ClubMeetRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<ClubMeetDto> GetAll()
        {
            var result = context.ClubMeets;

            if (result == null)
                return null;

            List<ClubMeetDto> clubMeetDtoList = new List<ClubMeetDto>();
            foreach (var clubMeet in result)
            {
                ClubMeetDto clubMeetDto = new ClubMeetDto()
                {
                    ClubMeetId = clubMeet.ClubMeetId,
                    Name = clubMeet.Name,
                    Venue = clubMeet.Venue,
                    MeetDate = clubMeet.MeetDate
                };
                clubMeetDtoList.Add(clubMeetDto);
            }
            return clubMeetDtoList;
        }

        public void AddClubMeet(int userId, ClubMeetDto clubMeetDto)
        {
            try
            {
                ClubMeet clubMeet = new ClubMeet()
                {
                    Name = clubMeetDto.Name,
                    Venue = clubMeetDto.Venue,
                    MeetDate = clubMeetDto.MeetDate,
                    CreatedUserId = userId,
                    CreatedDate = DateTime.Now,
                };

                unitOfWork.ClubMeets.Insert(clubMeet);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void UpdateClubMeet(int userId, ClubMeetDto clubMeetDto)
        {
            try
            {
                var result = unitOfWork.ClubMeets.GetFirstOrDefault(clubMeetDto.ClubMeetId);

                if (result == null)
                {
                    return;
                }
                result.ClubMeetId = clubMeetDto.ClubMeetId;
                result.Name = clubMeetDto.Name;
                result.Venue = clubMeetDto.Venue;
                result.MeetDate = clubMeetDto.MeetDate;
                result.ModifiedUserId = userId;
                result.ModifiedDate = DateTime.Now;

                unitOfWork.ClubMeets.Update(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void DeleteClubMeet(int clubMeetId)
        {
            try
            {
                var result = unitOfWork.ClubMeets.GetFirstOrDefault(clubMeetId);

                if (result == null)
                {
                    return;
                }
                unitOfWork.ClubMeets.Delete(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
