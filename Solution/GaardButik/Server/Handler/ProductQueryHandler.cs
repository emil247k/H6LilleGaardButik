using GaardButik.Server.Context;
using GaardButik.Server.Model;
using GaardButik.Server.Query;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Handler
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private IDatabaseContext databaseContext;
        public ProductQueryHandler(IDatabaseContext databaseContext) 
        {
            this.databaseContext = databaseContext;
        }

        public async Task<ICollection<Shared.Product>> Handle(ProductQuery query)
        {
            return await databaseContext.Instance.Set<Product>().Where(x => !x.IsSold && !x.IsDeleted).Select(x => new Shared.Product()
            {
                Name = x.Name,
                Price = x.Price,
                KGPrice = x.KGPrice,
                ExperationDate = x.ExperationDate,
                Id = x.Id,
            }).ToListAsync();
        }
    }
}
