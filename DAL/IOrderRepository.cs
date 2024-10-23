using ProductApi_Task.Models;
using System.Collections.Generic;

namespace ProductApi_Task.DataAccess
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersByUser(int userId);
        void AddOrder(Order order);
        void RemoveOrdersByUser(int userId);
    }
}
