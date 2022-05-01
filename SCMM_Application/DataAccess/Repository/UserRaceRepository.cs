using Microsoft.EntityFrameworkCore;
using SCMM_Application.DataAccess;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository
{
    public class UserRaceRepository : IUserRaceRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;
        public UserRaceRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<UserRaceDto> GetAll()
        {
            var result = context.UserRaces
                .Include(r => r.User)
                .Include(r => r.Race)
                .Include(r => r.Race.RaceType)
                .Include(r => r.Race.Stroke);

            if (result == null)
                return null;

            List<UserRaceDto> userRaceDtoList = new List<UserRaceDto>();
            foreach (var userRace in result)
            {
                UserRaceDto userRaceDto = new UserRaceDto()
                {
                    UserId = userRace.UserId,
                    UserName = userRace.User.Name,
                    RaceId = userRace.RaceId,
                    Timing = userRace.Timing,
                    Place = userRace.Place,
                    RaceTypeId = userRace.Race.RaceTypeId,
                    Gender = userRace.Race.RaceType.Gender,
                    Age = userRace.Race.RaceType.Age,
                    Distance = userRace.Race.RaceType.Distance,
                    StrokeId = userRace.Race.StrokeId,
                    StrokeName = userRace.Race.Stroke.Name,
                    Venue = userRace.Race.Venue
                };
                userRaceDtoList.Add(userRaceDto);
            }
            return userRaceDtoList;
        }

        public void AddUserRace(int userId, UserRaceDto userRaceDto)
        {
            try
            {
                UserRace userRace = new UserRace()
                {
                    UserId = userRaceDto.UserId,
                    RaceId = userRaceDto.RaceId,
                    Timing = userRaceDto.Timing,
                    Place = userRaceDto.Place,
                    CreatedUserId = userId,
                    CreatedDate = DateTime.Now
                };

                unitOfWork.UserRaces.Insert(userRace);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        public void UpdateUserRace(int userId, UserRaceDto userRaceDto)
        {
            try
            {
                var result = context.UserRaces.FirstOrDefault(x => x.UserId == userRaceDto.UserId && x.RaceId == userRaceDto.RaceId);

                if (result == null)
                {
                    return;
                }
                result.UserId = userRaceDto.UserId;
                result.RaceId = userRaceDto.RaceId;
                result.Timing = userRaceDto.Timing;
                result.Place = userRaceDto.Place;
                result.CreatedUserId = userId;
                result.CreatedDate = DateTime.Now;
                result.ModifiedUserId = userId;
                result.ModifiedDate = DateTime.Now;

                unitOfWork.UserRaces.Update(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void DeleteUserRace(int userRaceId)
        {
            try
            {
                var result = unitOfWork.UserRaces.GetFirstOrDefault(userRaceId);

                if (result == null)
                {
                    return;
                }
                unitOfWork.UserRaces.Delete(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
