using GaardButik.Shared.Command.Base;

namespace GaardButik.Shared.Command
{
    public class ProductDeleteCommand : ICommand
    {
        public List<long> ProductIds { get; set; }
    }
}
