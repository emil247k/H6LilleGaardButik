using GaardButik.Shared.Command.Base;

namespace GaardButik.Shared.Command
{
    public class ProductCreateCommand : ICommand
    {
        public long TypeId { get; set; }

        public string TypeName { get; set; }

        public string TypeDescription { get; set; }

        public string Name { get; set; }

        public DateTime ExperationDate { get; set; }

        public float? Price { get; set; }

        public float? KGPrice { get; set; }

        public long amount { get; set; }
    }
}
