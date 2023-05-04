using GaardButik.Server.Handler;
using GaardButik.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GaardButik.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductQueryHandler productQueryHandler;

        public ProductController(ILogger<ProductController> logger, IProductQueryHandler productQueryHandler)
        {
            this.productQueryHandler = productQueryHandler;
        }

        [HttpGet]
        public async Task<ICollection<Product>> Get()
        {
            return await productQueryHandler.Handle(new Query.ProductQuery());
        }
    }
}