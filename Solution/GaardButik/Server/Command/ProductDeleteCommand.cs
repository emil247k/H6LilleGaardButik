using GaardButik.Server.Command.Base;

namespace GaardButik.Server.Command
{
    public class ProductDeleteCommand : ICommand
    {
        public List<long> ProductIds { get; set; }
    }
}
