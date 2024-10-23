using ProductApi_Task.DTOs;
using System.Collections.Generic;

namespace ProductApi_Task.BusinessLogic
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        void AddProduct(ProductDTO productDto);
        void UpdateProduct(ProductDTO productDto);
        void DeleteProduct(int id);
    }
}
