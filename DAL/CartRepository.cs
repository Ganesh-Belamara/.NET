using ProductApi_Task.Data;
using ProductApi_Task.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi_Task.DataAccess
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cart> GetCartItems(int userId)
        {
            return _context.Carts.Where(c => c.UserID == userId).ToList();
        }

        public void AddCartItem(Cart cartItem)
        {
            _context.Carts.Add(cartItem);
            _context.SaveChanges();
        }

        public void RemoveCartItemsByUser(int userId)
        {
            var cartItems = _context.Carts.Where(c => c.UserID == userId);
            _context.Carts.RemoveRange(cartItems);
            _context.SaveChanges();
        }
    }
}
