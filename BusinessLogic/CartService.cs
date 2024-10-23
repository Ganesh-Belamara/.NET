using ProductApi_Task.DTOs;
using System.Collections.Generic;
using System.Linq;
using ProductApi_Task.DataAccess;
using ProductApi_Task.Models;

namespace ProductApi_Task.BusinessLogic
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IEnumerable<CartDTO> GetCartItems(int userId)
        {
            return _cartRepository.GetCartItems(userId)
                .Select(c => new CartDTO
                {
                    CartID = c.CartID,
                    UserID = c.UserID,
                    ProductID = c.ProductID,
                    Quantity = c.Quantity
                });
        }

        public void AddToCart(int userId, CartDTO cartDto)
        {
            var existingCartItem = _cartRepository.GetCartItems(userId)
                .FirstOrDefault(c => c.ProductID == cartDto.ProductID);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartDto.Quantity;
                _cartRepository.AddCartItem(existingCartItem); // Adjust to update if necessary
            }
            else
            {
                var newCartItem = new Cart
                {
                    UserID = userId,
                    ProductID = cartDto.ProductID,
                    Quantity = cartDto.Quantity
                };
                _cartRepository.AddCartItem(newCartItem);
            }
        }

        public void RemoveFromCart(int userId, int productId)
        {
            var cartItem = _cartRepository.GetCartItems(userId)
                .FirstOrDefault(c => c.ProductID == productId);

            if (cartItem != null)
            {
                _cartRepository.RemoveCartItemsByUser(userId);
            }
        }
    }
}
