using ProductApi_Task.Data;
using ProductApi_Task.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi_Task.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetOrdersByUser(int userId)
        {
            return _context.Orders.Where(o => o.UserID == userId).ToList();
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void RemoveOrdersByUser(int userId)
        {
            var orders = _context.Orders.Where(o => o.UserID == userId);
            _context.Orders.RemoveRange(orders);
            _context.SaveChanges();
        }
    }
}
