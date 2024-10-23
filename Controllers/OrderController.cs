using Microsoft.AspNetCore.Mvc;
using ProductApi_Task.DTOs;
using ProductApi_Task.BusinessLogic;
using System.Collections.Generic;

namespace ProductApi_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<OrderDTO>> GetOrdersByUser(int userId)
        {
            var orders = _orderService.GetOrdersByUser(userId);
            return Ok(orders);
        }

        [HttpPost("{userId}")]
        public ActionResult PlaceOrder(int userId)
        {
            _orderService.PlaceOrder(userId);
            return Ok(new { Message = "Order placed successfully." });
        }
    }
}
