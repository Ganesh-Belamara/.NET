using Microsoft.AspNetCore.Mvc;
using ProductApi_Task.DTOs;
using ProductApi_Task.BusinessLogic;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<CartDTO>> GetCartItems(int userId)
        {
            var cartItems = _cartService.GetCartItems(userId);
            if (cartItems == null || !cartItems.Any())
            {
                return NotFound(new { Message = "No items found in the cart." });
            }
            return Ok(cartItems);
        }

        [HttpPost("{userId}")]
        public ActionResult AddToCart(int userId, [FromBody] CartDTO cartDto)
        {
            _cartService.AddToCart(userId, cartDto);
            return CreatedAtAction(nameof(GetCartItems), new { userId }, new { Message = "Item added to cart successfully." });
        }

        [HttpDelete("{userId}/{productId}")]
        public ActionResult RemoveFromCart(int userId, int productId)
        {
            _cartService.RemoveFromCart(userId, productId);
            return NoContent();
        }
    }
}
