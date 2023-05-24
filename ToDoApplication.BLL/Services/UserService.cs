using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.BLL.DTO;
using ToDoApplication.BLL.Interface;
using ToDoApplication.Common;
using ToDoApplication.Common.Enums;
using ToDoApplication.DAL.Interface;

namespace ToDoApplication.BLL.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepos;
        public UserService(IUserRepository repos)
        {
            _userRepos = repos;
        }
        public async Task<User> AddUser(User model)
        {
            try
            {
                var existingUser = await _userRepos.GetUserByUsername(model.Username);
                if (existingUser != null)
                {
                    throw new Exception("Username ekziston! Krijo nje username te ri");
                }
                var user = new DAL.Entities.User
                {
                    Name = model.Name,
                    Username = model.Username,
                    Password = model.Password,
                    PersonType = PersonType.User
                };
                var addedUser = await _userRepos.AddUser(user);
                if (addedUser != null)
                {
                    return new DTO.User
                    {
                        Name = addedUser.Name,
                        Username = addedUser.Username,
                        Password = addedUser.Password,
                        PersonType = PersonType.User
                    };
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepos.GetUserById(id);
                if (user != null)
                {
                    return await _userRepos.DeleteUser(user);
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var users = await _userRepos.GetAllUsers();
                var newList = users.Select(x => new DTO.User
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                }).ToList();
                return newList;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await _userRepos.GetUserById(id);
                if (user != null)
                {
                    return new DTO.User
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Username = user.Username,
                    };
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<SessionPerson> Login(LoginForm model)
        {
            try
            {
                var userSession = await _userRepos.GetUser(model.Username, model.Password);
                if (userSession != null)
                {
                    return new SessionPerson
                    {
                        Id = userSession.Id,
                        Username = userSession.Username,
                        PersonType = userSession.PersonType
                    };
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<bool> UpdateUser(User model, int id)
        {
            try
            {
                var user = await _userRepos.GetUserById(id);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Username = model.Username;
                    user.Password = model.Password;
                    return await _userRepos.UpdateUser(user);
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
