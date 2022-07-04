using Microsoft.EntityFrameworkCore;
using REPO_DTO;
using REPO_Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Repository.Repositories
{
    public interface IAccountRepository : IRepository<LoginDTO>
    {
        Task<RolesDTO> login(string username, string password);
    }
    public class AccountRepository : Repository<LoginDTO>, IAccountRepository
    {
        public AccountRepository(Context context) : base(context)
        {

        }
        public async Task<RolesDTO> login(string username, string password)
        {
            var loginDTO = await (from u in _context.Users
                                  join r in _context.Roles on
                                  u.RoleId equals r.RoleId
                                  where u.UserName == username & u.Password == password
                                  select new RolesDTO
                                  {
                                      UserName = u.UserName,
                                      password = u.Password,
                                      RoleId = u.RoleId,
                                      RoleName = r.RoleName

                                  }).FirstOrDefaultAsync();

            return loginDTO;
        }
    }

}
