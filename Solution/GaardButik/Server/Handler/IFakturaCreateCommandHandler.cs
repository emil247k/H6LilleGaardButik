using GaardButik.Server.Handler.Base;
using GaardButik.Shared.Command;

namespace GaardButik.Server.Handler
{
    public interface IFakturaCreateCommandHandler : ICommandHandler<FakturaCreateCommand,string>
    {
    }
}
