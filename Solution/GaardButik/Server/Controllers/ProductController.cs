using GaardButik.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GaardButik.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            throw new NotImplementedException();
        }
    }
}