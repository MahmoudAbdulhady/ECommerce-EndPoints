using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Model;
namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult GetProduct()
        {
            var product = _productRepository.GetAllProducts;

            if(product == null)
            {
                return NotFound(new {Message="Product not found"});
            }
            return Ok(product);
        }

        
    
    
    }

 }

