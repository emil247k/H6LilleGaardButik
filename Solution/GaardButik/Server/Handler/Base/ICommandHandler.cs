using GaardButik.Shared.Command.Base;

namespace GaardButik.Server.Handler.Base
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand, TReturn> where TCommand : ICommand
    {
        Task<TReturn> Handle(TCommand command);
    }
}
