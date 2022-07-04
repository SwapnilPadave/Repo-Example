using REPO_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Service.Service_Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User Users);
        Task<User> UpdateUser(User Users);
        Task<User> DeleteUser(int id);
    }
}
