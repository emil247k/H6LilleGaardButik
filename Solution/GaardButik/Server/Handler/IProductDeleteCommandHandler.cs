using GaardButik.Server.Command;
using GaardButik.Server.Command.Base;
using GaardButik.Server.Handler.Base;

namespace GaardButik.Server.Handler
{
    public interface IProductDeleteCommandHandler : ICommandHandler<ProductDeleteCommand>
    {
    }
}
