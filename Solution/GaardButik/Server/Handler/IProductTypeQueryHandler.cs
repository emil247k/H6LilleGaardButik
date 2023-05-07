using GaardButik.Server.Handler.Base;
using GaardButik.Shared.Query;

namespace GaardButik.Server.Handler
{
    public interface IProductTypeQueryHandler : IQueryHandler<ProductTypeQuery, ICollection<Shared.ProductType>>
    {
    }
}
