using ProductApi_Task.DTOs;
using System.Collections.Generic;
using ProductApi_Task.DataAccess;
using ProductApi_Task.Models;
using System.Linq;

namespace ProductApi_Task.BusinessLogic
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, ICartService cartService, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _productRepository = productRepository;
        }

        public IEnumerable<OrderDTO> GetOrdersByUser(int userId)
        {
            return _orderRepository.GetOrdersByUser(userId)
                .Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    UserID = o.UserID,
                    Total_Amount = o.Total_Amount
                });
        }

        public void PlaceOrder(int userId)
        {
            var cartItems = _cartService.GetCartItems(userId);
            if (!cartItems.Any()) throw new InvalidOperationException("Cart is empty!");

            decimal totalAmount = 0;
            foreach (var cartItem in cartItems)
            {
                var product = _productRepository.GetProductById(cartItem.ProductID);
                if (product == null) throw new InvalidOperationException($"Product with ID {cartItem.ProductID} does not exist.");

                totalAmount += cartItem.Quantity * product.Price;
            }

            var order = new Order
            {
                UserID = userId,
                Total_Amount = totalAmount
            };

            _orderRepository.AddOrder(order);
            _cartService.RemoveFromCart(userId, 0); // Remove all cart items for this user
        }
    }
}
