using GaardButik.Server.Query.Base;

namespace GaardButik.Server.Handler.Base
{
    public interface IQueryHandler<TQuery,TReturn> where TQuery : IQuery
    {
        Task<TReturn> Handle(TQuery query);
    }
}
