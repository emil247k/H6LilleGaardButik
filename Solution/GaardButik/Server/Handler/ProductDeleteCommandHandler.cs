using GaardButik.Server.Command;
using GaardButik.Server.Context;
using GaardButik.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Handler
{
    public class ProductDeleteCommandHandler : IProductDeleteCommandHandler
    {
        private IDatabaseContext databaseContext;
        public ProductDeleteCommandHandler(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Handle(ProductDeleteCommand command)
        {
            var productsToRemove = databaseContext.Instance.Set<Product>().Where(x => command.ProductIds.Contains(x.Id));
            await productsToRemove.ForEachAsync(x => x.IsDeleted = true);
            await databaseContext.Instance.SaveChangesAsync();
        }
    }
}
