using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REPO_DTO;
using REPO_MODEL;
using REPO_Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REPO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Product>))]
        public async Task<IActionResult> GetProductList()
        {
            IEnumerable<Product> products = await _productService.GetAllProduct();
            return Ok(products);
        }

        
        [HttpPost]
        [Authorize(Policy = "Admin")]

        public async Task<IActionResult> AddProduct(ProductAddDTO addDTO)
        {
            return Ok( await _productService.AddProduct(addDTO));
        }

        
        [HttpPut]
        [Route("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO productDTO)
        {
            return Ok(await _productService.UpdateProduct(productDTO));
        }
        
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<Product> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}
