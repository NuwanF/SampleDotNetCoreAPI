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
                   StudentName = squad.Student.Name,
                   CoachId = squad.CoachId,
                   CoachName = squad.Coach.Name
                };
                squadDtoList.Add(squadDto);
            }
            return squadDtoList;
        }
    }
}
