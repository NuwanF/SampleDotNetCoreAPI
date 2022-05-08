using SCMM_Application.DataAccess;
using SCMM_Application.DataAccess.Models;
using SCMM_Application.DataAccess.Repository;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private SwimClubDBContext context;
        private BaseRepository<User> user;
        private BaseRepository<UserRole> userRole;
        private BaseRepository<Squad> squad;
        private BaseRepository<Performance> performance;
        private BaseRepository<UserRace> userRace;
        private BaseRepository<Race> race;
        private BaseRepository<ClubMeet> clubMeet;
        private BaseRepository<Stroke> stroke;
        private BaseRepository<Stage> stage;
        public UnitOfWork(SwimClubDBContext context)
        {
            this.context = context;
        }

        public IBaseRepository<User> Users
        {
            get
            {
                return user ??
                    (user = new BaseRepository<User>(context));
            }
        }

        public IBaseRepository<UserRole> UserRoles
        {
            get
            {
                return userRole ??
                    (userRole = new BaseRepository<UserRole>(context));
            }
        }

        public IBaseRepository<Squad> Squads
        {
            get
            {
                return squad ??
                    (squad = new BaseRepository<Squad>(context));
            }
        }

        public IBaseRepository<Performance> Performances
        {
            get
            {
                return performance ??
                    (performance = new BaseRepository<Performance>(context));
            }
        }

        public IBaseRepository<UserRace> UserRaces
        {
            get
            {
                return userRace ??
                    (userRace = new BaseRepository<UserRace>(context));
            }
        }

        public IBaseRepository<Race> Races
        {
            get
            {
                return race ??
                    (race = new BaseRepository<Race>(context));
            }
        }

        public IBaseRepository<ClubMeet> ClubMeets
        {
            get
            {
                return clubMeet ??
                    (clubMeet = new BaseRepository<ClubMeet>(context));
            }
        }

        public IBaseRepository<Stroke> Strokes
        {
            get
            {
                return stroke ??
                    (stroke = new BaseRepository<Stroke>(context));
            }
        }

        public IBaseRepository<Stage> Stages
        {
            get
            {
                return stage ??
                    (stage = new BaseRepository<Stage>(context));
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async void CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
