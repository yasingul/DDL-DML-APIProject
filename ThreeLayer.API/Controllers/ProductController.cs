using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeLayer.Service;

namespace ThreeLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responses = await _productService.GetAll();
            return new ObjectResult(responses) { StatusCode = responses.Status };
        }
    }
}