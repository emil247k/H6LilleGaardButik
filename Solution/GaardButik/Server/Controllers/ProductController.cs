using GaardButik.Server.Command;
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
        private IProductCreateCommandHandler productCreateCommandHandler;
        private IProductDeleteCommandHandler productDeleteCommandHandler;
        private IProductSoldCommandHandler productSoldCommandHandler;

        public ProductController(
            IProductQueryHandler productQueryHandler,
            IProductCreateCommandHandler productCreateCommandHandler,
            IProductDeleteCommandHandler productDeleteCommandHandler,
            IProductSoldCommandHandler productSoldCommandHandler)
        {
            this.productQueryHandler = productQueryHandler;
            this.productCreateCommandHandler = productCreateCommandHandler;
            this.productDeleteCommandHandler = productDeleteCommandHandler;
            this.productSoldCommandHandler = productSoldCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productQueryHandler.Handle(new Query.ProductQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateCommand productCreateCommand)
        {
            await productCreateCommandHandler.Handle(productCreateCommand);
            return Ok();
        }

        [HttpPost("/Delete")]
        public async Task<IActionResult> Delete([FromBody] ProductDeleteCommand productDeleteCommand)
        {
            await productDeleteCommandHandler.Handle(productDeleteCommand);
            return Ok();
        }

        [HttpPost("/Sold")]
        public async Task<IActionResult> Sold([FromBody] ProductSoldCommand productSoldCommand)
        {
            await productSoldCommandHandler.Handle(productSoldCommand);
            return Ok();
        }
    }
}