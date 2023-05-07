using GaardButik.Server.Command;
using GaardButik.Server.Context;
using GaardButik.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Handler
{
    public class ProductSoldCommandHandler : IProductSoldCommandHandler
    {
        private IDatabaseContext databaseContext;
        public ProductSoldCommandHandler(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Handle(ProductSoldCommand command)
        {
            var productsSold = databaseContext.Instance.Set<Product>().Where(x => command.ProductIds.Contains(x.Id));
            await productsSold.ForEachAsync(x => x.IsSold = true);
            await databaseContext.Instance.SaveChangesAsync();
        }
    }
}
