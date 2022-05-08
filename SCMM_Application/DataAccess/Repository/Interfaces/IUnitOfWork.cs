using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<User> Users { get; }
        IBaseRepository<UserRole> UserRoles { get; }

        IBaseRepository<Squad> Squads { get; }

        IBaseRepository<Performance> Performances { get; }

        IBaseRepository<UserRace> UserRaces { get; }

        IBaseRepository<Race> Races { get; }

        IBaseRepository<ClubMeet> ClubMeets { get; }

        IBaseRepository<Stroke> Strokes { get; }

        IBaseRepository<Stage> Stages { get; }

        public void Commit();

        public void CommitAsync();
    }
}
