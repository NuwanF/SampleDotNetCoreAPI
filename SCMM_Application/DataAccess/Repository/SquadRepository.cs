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
    public class SquadRepository: ISquadRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;

        public SquadRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<SquadDto> GetAll()
        {
            var result = context.Squads
                .Include(r => r.Coach)
                .Include(r => r.Student);

            if (result == null)
                return null;

            List<SquadDto> squadDtoList = new List<SquadDto>();
            foreach (var squad in result)
            {
                SquadDto squadDto = new SquadDto()
                {
                   SquadId = squad.SquadId,
                   Name = squad.Name,
                   StudentId = squad.StudentId,
                   StudentName = squad.Student.Name + " " + squad.Student.Surname,
                   CoachId = squad.CoachId,
                   CoachName = squad.Coach.Name + " " + squad.Coach.Surname
                };
                squadDtoList.Add(squadDto);
            }
            return squadDtoList;
        }

        public void AddSquad(int userId, SquadDto squadDto)
        {
            try
            {
                Squad squad = new Squad()
                {
                    Name = squadDto.Name,
                    StudentId = squadDto.StudentId,
                    CoachId = squadDto.CoachId,
                    CreatedUserId = userId,
                    CreatedDate = DateTime.Now
                };

                unitOfWork.Squads.Insert(squad);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        public void UpdateSquad(int userId, SquadDto squadDto)
        {
            try
            {
                var result = unitOfWork.Squads.GetFirstOrDefault(squadDto.SquadId);

                if (result == null)
                {
                    return;
                }
                result.SquadId = squadDto.SquadId;
                result.Name = squadDto.Name;
                result.StudentId = squadDto.StudentId;
                result.CoachId = squadDto.CoachId;
                result.ModifiedUserId = userId;
                result.ModifiedDate = DateTime.Now;

                unitOfWork.Squads.Update(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void DeleteSquad(int squadId)
        {
            try
            {
                var result = unitOfWork.Squads.GetFirstOrDefault(squadId);

                if (result == null)
                {
                    return;
                }
                unitOfWork.Squads.Delete(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
