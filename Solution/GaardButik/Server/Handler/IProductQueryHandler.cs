using GaardButik.Server.Handler.Base;
using GaardButik.Server.Query;
using GaardButik.Server.Query.Base;

namespace GaardButik.Server.Handler
{
    public interface IProductQueryHandler : IQueryHandler<ProductQuery, ICollection<Shared.Product>>
    {
    }
}
