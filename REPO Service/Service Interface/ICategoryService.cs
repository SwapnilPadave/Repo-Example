using REPO_DTO;
using REPO_MODEL;
using REPO_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO_Service
{
    public interface ICategoryService
    {

        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
        Task<Category> AddCategory(CategoryAddDTO addDTO);
        Task<Category> UpdateCategory(CategoryUpdateDTO updateDTO);
        Task<Category> DeleteCategory(int id);

    }
    
}
