﻿using GaardButik.Server.Handler.Base;
using GaardButik.Shared.Query;

namespace GaardButik.Server.Handler
{
    public interface IProductQueryHandler : IQueryHandler<ProductQuery, ICollection<Shared.Product>>
    {
    }
}
