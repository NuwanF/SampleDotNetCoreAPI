﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCMM_Application.DataAccess;

namespace SCMM_Application.Migrations
{
    [DbContext(typeof(SwimClubDBContext))]
    [Migration("20220430012323_udate_remove_foreign_key_dependencies")]
    partial class udate_remove_foreign_key_dependencies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Performance", b =>
                {
                    b.Property<int>("PerformanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<decimal>("PersonalBestTime")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<int>("StrokeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PerformanceId");

                    b.HasIndex("StageId");

                    b.HasIndex("StrokeId");

                    b.HasIndex("UserId");

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RaceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RaceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StrokeId")
                        .HasColumnType("int");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("RaceId");

                    b.HasIndex("RaceTypeId");

                    b.HasIndex("StrokeId");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.RaceType", b =>
                {
                    b.Property<int>("RaceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RaceTypeId");

                    b.ToTable("RaceType");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Squad", b =>
                {
                    b.Property<int>("SquadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("SquadId");

                    b.HasIndex("CoachId");

                    b.HasIndex("StudentId");

                    b.ToTable("Squad");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Stage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("StageId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Stroke", b =>
                {
                    b.Property<int>("StrokeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("StrokeId");

                    b.ToTable("Stroke");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.UserRace", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUserId")
                        .HasColumnType("int");

                    b.Property<int>("Place")
                        .HasColumnType("int");

                    b.Property<decimal>("Timing")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("UserId", "RaceId");

                    b.HasIndex("RaceId");

                    b.ToTable("UserRace");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Performance", b =>
                {
                    b.HasOne("SCMM_Application.DataAccess.Models.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SCMM_Application.DataAccess.Models.Stroke", "Stroke")
                        .WithMany()
                        .HasForeignKey("StrokeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SCMM_Application.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Race", b =>
                {
                    b.HasOne("SCMM_Application.DataAccess.Models.RaceType", "RaceType")
                        .WithMany()
                        .HasForeignKey("RaceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SCMM_Application.DataAccess.Models.Stage", "Stroke")
                        .WithMany()
                        .HasForeignKey("StrokeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.Squad", b =>
                {
                    b.HasOne("SCMM_Application.DataAccess.Models.User", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SCMM_Application.DataAccess.Models.User", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.User", b =>
                {
                    b.HasOne("SCMM_Application.DataAccess.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SCMM_Application.DataAccess.Models.UserRace", b =>
                {
                    b.HasOne("SCMM_Application.DataAccess.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SCMM_Application.DataAccess.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
