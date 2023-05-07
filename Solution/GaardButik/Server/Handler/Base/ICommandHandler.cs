using GaardButik.Server.Command.Base;

namespace GaardButik.Server.Handler.Base
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
