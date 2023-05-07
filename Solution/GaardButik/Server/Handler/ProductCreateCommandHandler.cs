using GaardButik.Server.Command;
using GaardButik.Server.Context;
using GaardButik.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Handler
{
    public class ProductCreateCommandHandler : IProductCreateCommandHandler
    {
        private IDatabaseContext databaseContext;
        public ProductCreateCommandHandler(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Handle(ProductCreateCommand command)
        {
            var productType = new ProductType()
            {
                Name = command.TypeName,
                Description = command.TypeDescription
            };

            if(command.TypeId != 0)
            {
                productType = await databaseContext.Instance.Set<ProductType>().SingleAsync(x => x.Id == command.TypeId);
            }

            var product = new Product()
            {
                Name = command.Name,
                ExperationDate = command.ExperationDate,
                Price = command.Price,
                KGPrice = command.KGPrice,
                TypeId = command.TypeId,
                Type = productType,
                IsDeleted = false,
                IsSold = false,

            };
            for (int i = 0; i<command.amount; i++)
            {
                await databaseContext.Instance.Set<Product>().AddAsync(product);
            }
            await databaseContext.Instance.SaveChangesAsync();
        }
    }
}