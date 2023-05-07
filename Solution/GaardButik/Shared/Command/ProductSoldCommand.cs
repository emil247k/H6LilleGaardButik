using GaardButik.Shared.Command.Base;

namespace GaardButik.Shared.Command
{
    public class ProductSoldCommand : ICommand
    {
        public List<long> ProductIds { get; set; }
    }
}
