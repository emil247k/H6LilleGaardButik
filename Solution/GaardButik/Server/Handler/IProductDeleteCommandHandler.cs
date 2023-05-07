using GaardButik.Shared.Command;
using GaardButik.Server.Handler.Base;

namespace GaardButik.Server.Handler
{
    public interface IProductDeleteCommandHandler : ICommandHandler<ProductDeleteCommand>
    {
    }
}
