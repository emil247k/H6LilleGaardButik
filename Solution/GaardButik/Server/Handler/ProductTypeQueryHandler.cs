using GaardButik.Server.Context;
using GaardButik.Server.Model;
using GaardButik.Shared.Query;
using Microsoft.EntityFrameworkCore;

namespace GaardButik.Server.Handler
{
    public class ProductTypeQueryHandler : IProductTypeQueryHandler
    {
        private IDatabaseContext databaseContext;
        public ProductTypeQueryHandler(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<ICollection<Shared.ProductType>> Handle(ProductTypeQuery query)
        {
            return await databaseContext.Instance.Set<ProductType>().Select(x => new Shared.ProductType()
            {
                Name = x.Name,
                Description = x.Description,
                Id = x.Id,
            }).ToListAsync();
        }
    }
}
