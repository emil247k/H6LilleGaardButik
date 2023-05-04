using GaardButik.Server.Context;
using GaardButik.Server.Model;
using GaardButik.Server.Query;

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
            return databaseContext.Instance.Set<Product>().Select(x => new Shared.Product()
            {
                Name = x.Name,
                Price = x.Price,
                KGPrice = x.KGPrice,
                ExperationDate = x.ExperationDate,
                Id = x.Id,
            }).ToList();
        }
    }
}
