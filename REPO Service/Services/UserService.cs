using REPO_MODEL;
using REPO_Repository.Repositories;
using REPO_Service.Service_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddUser(User Users)
        {
            Users.CreatedDate = DateTime.Now;
            try
            {
                await _userRepository.Add(Users);
                return Users;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            User user = await GetUserById(id);
            if (user != null)
            {
                await _userRepository.Delete(user);
                return user;
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _userRepository.Get();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> UpdateUser(User Users)
        {
            try
            {
                User user = await GetUserById(Users.UserId);
                if (user != null)
                {
                    user.UserName = Users.UserName;
                    user.Password = Users.Password;
                    await _userRepository.Update(user);
                }

                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
