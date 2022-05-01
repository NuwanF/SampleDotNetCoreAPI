﻿using SCMM_Application.DataAccess;
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
