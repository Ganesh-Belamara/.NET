using ProductApi_Task.DTOs;
using System.Collections.Generic;
using ProductApi_Task.DataAccess;
using ProductApi_Task.Models;
using System.Linq;

namespace ProductApi_Task.BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _productRepository.GetAllProducts().Select(p => new ProductDTO
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.Price
            });
        }

        public ProductDTO GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null) return null;

            return new ProductDTO
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Price = product.Price
            };
        }

        public void AddProduct(ProductDTO productDto)
        {
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price
            };
            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(ProductDTO productDto)
        {
            var product = _productRepository.GetProductById(productDto.ProductID);
            if (product != null)
            {
                product.ProductName = productDto.ProductName;
                product.Price = productDto.Price;
                _productRepository.UpdateProduct(product);
            }
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}
