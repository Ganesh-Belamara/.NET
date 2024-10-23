using ProductApi_Task.Models;
using System.Collections.Generic;

namespace ProductApi_Task.DataAccess
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
