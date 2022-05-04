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
    public class RaceRepository : IRaceRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;
        public RaceRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<RaceDto> GetAll()
        {
            var result = context.Races
                .Include(r => r.ClubMeet)
                .Include(r => r.Stroke);

            if (result == null)
                return null;

            List<RaceDto> raceDtoList = new List<RaceDto>();
            foreach (var race in result)
            {
                RaceDto raceDto = new RaceDto()
                {
                    RaceId = race.RaceId,
                    Name = race.Name,
                    ClubMeetId = race.ClubMeetId,
                    Gender = race.Gender,
                    Age = race.Age,
                    Distance = race.Distance,
                    StrokeId = race.StrokeId,
                    StrokeName = race.Stroke.Name,
                    Venue = race.ClubMeet.Venue,
                    MeetDate = race.ClubMeet.MeetDate
                };
                raceDtoList.Add(raceDto);
            }
            return raceDtoList;
        }

        public void AddRace(int userId, RaceDto raceDto)
        {
            try
            {
                Race race = new Race()
                {
                    Name = raceDto.Name,
                    ClubMeetId = raceDto.ClubMeetId,
                    StrokeId = raceDto.StrokeId,
                    Gender = raceDto.Gender,
                    Age = raceDto.Age,
                    Distance = raceDto.Distance,
                    CreatedUserId = userId,
                    CreatedDate = DateTime.Now,
                };

                unitOfWork.Races.Insert(race);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void UpdateRace(int userId, RaceDto raceDto)
        {
            try
            {
                var result = unitOfWork.Races.GetFirstOrDefault(raceDto.RaceId);

                if (result == null)
                {
                    return;
                }
                result.RaceId = raceDto.RaceId;
                result.Name = raceDto.Name;
                result.StrokeId = raceDto.StrokeId;
                result.Gender = raceDto.Gender;
                result.Age = raceDto.Age;
                result.Distance = raceDto.Distance;
                result.ModifiedUserId = userId;
                result.ModifiedDate = DateTime.Now;

                unitOfWork.Races.Update(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void DeleteRace(int raceId)
        {
            try
            {
                var result = unitOfWork.Races.GetFirstOrDefault(raceId);

                if (result == null)
                {
                    return;
                }
                unitOfWork.Races.Delete(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
