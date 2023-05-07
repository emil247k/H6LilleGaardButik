using GaardButik.Server.Command.Base;

namespace GaardButik.Server.Command
{
    public class ProductSoldCommand : ICommand
    {
        public List<long> ProductIds { get; set; }
    }
}
