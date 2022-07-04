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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProduct(ProductAddDTO productDTO)
        {
            try
            {
                var product = new Product();
                product.ProductName = productDTO.productName;
                product.CategoryId = productDTO.catagoryId;

                await _productRepository.Add(product);

                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Product> DeleteProduct(int id)
        {
            Product product = await GetProductById(id);
            if (product != null)
            {
                await _productRepository.Delete(product);
                return product;
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.Get();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product> UpdateProduct(ProductUpdateDTO productDTO)
        {
            try
            {
                Product _product = await GetProductById(productDTO.ProductId);
                if (_product != null)
                {
                    _product.ProductName = productDTO.productName;
                    _product.CategoryId = productDTO.catagoryId;
                    await _productRepository.Update(_product);
                }

                return _product;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
