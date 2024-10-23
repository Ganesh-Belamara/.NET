using ProductApi_Task.DTOs;
using System.Collections.Generic;

namespace ProductApi_Task.BusinessLogic
{
    public interface ICartService
    {
        IEnumerable<CartDTO> GetCartItems(int userId);
        void AddToCart(int userId, CartDTO cartDto);
        void RemoveFromCart(int userId, int productId);
    }
}
