using ProductApi_Task.Data;
using ProductApi_Task.Models;

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
            var resultList =  _context.Orders.Where(o => o.UserID == userId).ToList();
            return resultList;
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
