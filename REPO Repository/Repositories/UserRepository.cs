using REPO_MODEL;
using REPO_Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Repository.Repositories
{
    public interface IUserRepository :IRepository<User>
    {

    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context):base(context)
        {

        }
    }
}
