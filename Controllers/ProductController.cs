using Microsoft.AspNetCore.Mvc;
using ProductApi_Task.DTOs;
using ProductApi_Task.BusinessLogic;
using System.Collections.Generic;

namespace ProductApi_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductDTO productDto)
        {
            _productService.AddProduct(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.ProductID }, new { Message = "Product added successfully." });
        }

        [HttpPut]
        public ActionResult UpdateProduct([FromBody] ProductDTO productDto)
        {
            _productService.UpdateProduct(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
