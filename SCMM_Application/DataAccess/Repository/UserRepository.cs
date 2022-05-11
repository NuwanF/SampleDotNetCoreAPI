using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SCMM_Application.DataAccess;
using SCMM_Application.DataAccess.DomainModels;
using SCMM_Application.DataAccess.Models;
using SCMM_Application.DataAccess.Repository.Interfaces;
using SCMM_Application.Helper;
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
            try
            {
                var result = context.Users
                .Include(r => r.UserRole)
                .Include(r => r.Parent);

                if (result == null)
                    return null;

                List<UserDto> userDtoList = new List<UserDto>();
                foreach (var user in result)
                {
                    UserDto userDto = new UserDto()
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        Surname = user.Surname,
                        DOB = user.DOB,
                        Gender = user.Gender,
                        Email = user.Email,
                        Address = user.Address,
                        Postcode = user.Postcode,
                        Mobile = user.Mobile,
                        Username = user.Username,
                        Password = user.Password,
                        UserRoleId = user.UserRoleId,
                        UserRoleName = user.UserRole.Name,
                        ParentId = user.ParentId,
                        ParentName = user.Parent != null ? user.Parent.Name : null
                    };
                    userDtoList.Add(userDto);
                }
                return userDtoList;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            
        }

        public UserDto GetById(int userId)
        {
            try
            {
                var result = context.Users.Include(r => r.UserRole).FirstOrDefault(x => x.UserId == userId);

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
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

        public UserDto GetByCredentials(string username, string password)
        {
            try
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
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }

        public void AddUser(UserDto userDto)
        {
            var result = context.Users.FirstOrDefault(x => x.Username.ToLower() == userDto.Username.ToLower());

            if (result != null)
                throw new Exception("User already exist");

            try
            {

                User user = new User()
                {
                    UserRoleId = 5,
                    Name = userDto.Name,
                    Surname = userDto.Surname,
                    DOB = userDto.DOB,
                    Gender = userDto.Gender,
                    Email = userDto.Email,
                    Address = userDto.Address,
                    Postcode = userDto.Postcode,
                    Mobile = userDto.Mobile,
                    Username = userDto.Username,
                    Password = userDto.Password,
                    CreatedDate = DateTime.Now
                };

                unitOfWork.Users.Insert(user);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            
        }

        public void UpdateUser(UserDto userDto)
        {
            try
            {
                var result = unitOfWork.Users.GetFirstOrDefault(userDto.UserId);

                if (result == null)
                {
                    return;
                }

                result.UserRoleId = userDto.UserRoleId;
                result.Name = userDto.Name;
                result.Surname = userDto.Surname;
                result.DOB = userDto.DOB;
                result.Gender = userDto.Gender;
                result.Email = userDto.Email;
                result.Address = userDto.Address;
                result.Postcode = userDto.Postcode;
                result.Mobile = userDto.Mobile;
                result.Username = userDto.Username;
                result.Password = userDto.Password;
                result.ParentId = userDto.ParentId;
                result.ModifiedDate = DateTime.Now;

                unitOfWork.Users.Update(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void DeleteUser(int userId)
        {
            try
            {
                var result = unitOfWork.Users.GetFirstOrDefault(userId);

                if (result == null)
                {
                    return;
                }
                unitOfWork.Users.Delete(result);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

    }
}
