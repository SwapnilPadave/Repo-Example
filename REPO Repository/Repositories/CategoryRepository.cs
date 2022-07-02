using REPO_MODEL;
using REPO_Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Repository.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CatrgoryRepository : Repository<Category>, ICategoryRepository
    {
        public CatrgoryRepository(Context context) : base(context)
        {

        }
    }
}
