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
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(ProductAddDTO productAdd);
        Task<Product> UpdateProduct(ProductUpdateDTO productUpdate);
        Task<Product> DeleteProduct(int id);
    }
   
}
