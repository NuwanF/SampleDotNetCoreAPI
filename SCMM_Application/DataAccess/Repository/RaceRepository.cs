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
                .Include(r => r.RaceType)
                .Include(r => r.Stroke);

            if (result == null)
                return null;

            List<RaceDto> raceDtoList = new List<RaceDto>();
            foreach (var race in result)
            {
                RaceDto raceDto = new RaceDto()
                {
                    RaceId = race.RaceId,
                    RaceTypeId = race.RaceTypeId,
                    Gender = race.RaceType.Gender,
                    Age = race.RaceType.Age,
                    Distance = race.RaceType.Distance,
                    StrokeId = race.StrokeId,
                    StrokeName = race.Stroke.Name,
                    Venue = race.Venue,
                    RaceDate = race.RaceDate
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
                    RaceTypeId = raceDto.RaceTypeId,
                    StrokeId = raceDto.StrokeId,
                    Venue = raceDto.Venue,
                    RaceDate = raceDto.RaceDate,
                    CreatedUserId = userId,
                    CreatedDate = DateTime.Now
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
                result.StrokeId = raceDto.StrokeId;
                result.Venue = raceDto.Venue;
                result.RaceDate = raceDto.RaceDate;
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
