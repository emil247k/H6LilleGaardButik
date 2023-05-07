using GaardButik.Shared.Command;
using GaardButik.Server.Handler;
using Microsoft.AspNetCore.Mvc;
using GaardButik.Shared.Query;

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
        private IProductTypeQueryHandler productTypeQueryHandler;

        public ProductController(
            IProductQueryHandler productQueryHandler,
            IProductCreateCommandHandler productCreateCommandHandler,
            IProductDeleteCommandHandler productDeleteCommandHandler,
            IProductSoldCommandHandler productSoldCommandHandler,
            IProductTypeQueryHandler productTypeQueryHandler)
        {
            this.productQueryHandler = productQueryHandler;
            this.productCreateCommandHandler = productCreateCommandHandler;
            this.productDeleteCommandHandler = productDeleteCommandHandler;
            this.productSoldCommandHandler = productSoldCommandHandler;
            this.productTypeQueryHandler = productTypeQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productQueryHandler.Handle(new ProductQuery()));
        }

        [HttpGet]
        [Route("ProductType")]
        public async Task<IActionResult> GetProductType()
        {
            return Ok(await productTypeQueryHandler.Handle(new ProductTypeQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateCommand productCreateCommand)
        {
            await productCreateCommandHandler.Handle(productCreateCommand);
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] ProductDeleteCommand productDeleteCommand)
        {
            await productDeleteCommandHandler.Handle(productDeleteCommand);
            return Ok();
        }

        [HttpPost]
        [Route("Sold")]
        public async Task<IActionResult> Sold([FromBody] ProductSoldCommand productSoldCommand)
        {
            await productSoldCommandHandler.Handle(productSoldCommand);
            return Ok();
        }
    }
}