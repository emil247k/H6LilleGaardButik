using GaardButik.Shared.Command;
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

            if(Validate(command))
            {
                throw new Exception("Et eller flere felter er ikke udfyldt rigtigt");
            }

            if(command.TypeId != 0)
            {
                productType = await databaseContext.Instance.Set<ProductType>().SingleAsync(x => x.Id == command.TypeId);
            }
            else if (await databaseContext.Instance.Set<ProductType>().AnyAsync(x => x.Name == command.TypeName))
            {
                throw new Exception("Der exister alrede en produkt type med dette navn");
            }

            var product = new Product()
            {
                Name = command.Name,
                ExperationDate = command.ExperationDate,
                Price = command.Price,
                KGPrice = command.KGPrice,
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
        
        public bool Validate(ProductCreateCommand command)
        {
            return string.IsNullOrWhiteSpace(command.Name) ||
                (command.Price == 0 && command.KGPrice == 0) ||
                command.ExperationDate == default ||
                command.amount == 0;
        }
    }
}