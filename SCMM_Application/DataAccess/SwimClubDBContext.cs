using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SCMM_Application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCMM_Application.DataAccess
{
    public class SwimClubDBContext : DbContext
    {
        public SwimClubDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRace>().HasKey(q => new
            {
                q.UserId,
                q.RaceId
            });

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //This will singularize all table names
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }
        }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RaceType> RaceTypes { get; set; }

        public DbSet<Stroke> Strokes { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Squad> Squads { get; set; }

        public DbSet<Performance> Performances { get; set; }

        public DbSet<Race> Races { get; set; }

        public DbSet<UserRace> UserRaces { get; set; }

    }
}
