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
    public class CategoryService :ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategory(CategoryAddDTO addDTO)
        {

            try
            {
                var category = new Category();
                category.CategoryName = addDTO.CategoryName;
                await _categoryRepository.Add(category);
                return category;
                //return true;
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
        }

        public async Task<Category> DeleteCategory(int id)
        {
            Category category = await GetCategoryById(id);
            if (category != null)
            {
                await _categoryRepository.Delete(category);
                return category;
            }
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> UpdateCategory(CategoryUpdateDTO updateDTO)
        {
            try
            {
                var category = new Category();
                category.CategoryId = updateDTO.CategoryId;
                category.CategoryName = updateDTO.CategoryName.Trim();

                Category _category = await GetCategoryById(category.CategoryId);
                if (_category != null)
                {
                    _category.CategoryName = category.CategoryName;

                    await _categoryRepository.Update(_category);
                }

                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
