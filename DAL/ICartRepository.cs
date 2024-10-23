using ProductApi_Task.Models;
using System.Collections.Generic;

namespace ProductApi_Task.DataAccess
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetCartItems(int userId);
        void AddCartItem(Cart cartItem);
        void RemoveCartItemsByUser(int userId);
    }
}
