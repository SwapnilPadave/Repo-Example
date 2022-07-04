using System.Collections.Generic;
using System.Threading.Tasks;

namespace REPO_Repository.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);

        Task<T> Add(T entity);

        Task Update(T entity);
        Task Delete(T entity);
    }
}
