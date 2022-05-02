using Microsoft.Extensions.DependencyInjection;
using SCMM_Application.BusinessLogic;
using SCMM_Application.BusinessLogic.Interfaces;
using SCMM_Application.DataAccess.Repository;
using SCMM_Application.DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.Helper
{
    public static class DIRegistry
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IUserRoleRepository, UserRoleRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserManager, UserManager>()
                .AddTransient<ISquadRepository, SquadRepository>()
                .AddTransient<ISquadManager, SquadManager>()
                .AddTransient<IPerformanceRepository, PerformanceRepository>()
                .AddTransient<IPerformanceManager, PerformanceManager>()
                .AddTransient<IUserRaceRepository, UserRaceRepository>()
                .AddTransient<IUserRaceManager, UserRaceManager>()
                .AddTransient<IRaceRepository, RaceRepository>()
                .AddTransient<IRaceManager, RaceManager>()
                .AddTransient<IClubMeetRepository, ClubMeetRepository>()
                .AddTransient<IClubMeetManager, ClubMeetManager>();
            return services;
        }
    }
}
