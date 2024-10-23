using ProductApi_Task.DTOs;
using System.Collections.Generic;

namespace ProductApi_Task.BusinessLogic
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetOrdersByUser(int userId);
        void PlaceOrder(int userId);
    }
}
