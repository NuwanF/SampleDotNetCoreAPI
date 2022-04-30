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
    public class UserRepository: IUserRepository
    {
        private readonly SwimClubDBContext context;
        private readonly IUnitOfWork unitOfWork;
        public UserRepository(SwimClubDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public List<UserDto> GetAll()
        {
            var result = context.Users.Include(r => r.UserRole);

            if (result == null)
                return null;

            List<UserDto> userDtoList = new List<UserDto>();
            foreach (var user in result)
            {
                UserDto userDto = new UserDto()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    DOB = user.DOB,
                    Gender = user.Gender,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    Username = user.Username,
                    Password = user.Password,
                    UserRoleId = user.UserRoleId,
                    UserRoleName = user.UserRole.Name
                };
                userDtoList.Add(userDto);
            }
            return userDtoList;
        }

        public UserDto GetByCredentials(string username, string password)
        {
            var result = context.Users.Include(r => r.UserRole).FirstOrDefault(x => x.Username == username && x.Password == password);

            if (result == null)
                return null;

            UserDto userDto = new UserDto()
            {
                UserId = result.UserId,
                Name = result.Name,
                DOB = result.DOB,
                Email = result.Email,
                Mobile = result.Mobile,
                Username = result.Username,
                Password = result.Password,
                UserRoleId = result.UserRoleId,
                UserRoleName = result.UserRole.Name
            };

            return userDto;
        }
    }
}
