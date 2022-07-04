using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REPO_DTO;
using REPO_MODEL;
using REPO_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REPO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Category>))]
        public async Task<IActionResult> GetCategoryList()
        {
            IEnumerable<Category> category = await _categoryService.GetAllCategory();
            return Ok(category);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [Produces(typeof(Category))]
        public async Task<IActionResult> AddCategoryAsync(CategoryAddDTO1 addDTO)
        {
            return Ok(await _categoryService.AddCategory(addDTO));
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO updateDTO)
        {
            return Ok(await _categoryService.UpdateCategory(updateDTO));
        }
       
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<Category> DeleteCategory(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }

    }
}

