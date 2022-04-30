using Microsoft.EntityFrameworkCore;
using SCMM_Application.DataAccess;
using SCMM_Application.DataAccess.DomainModels;
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
    }
}
