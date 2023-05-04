namespace GaardButik.Server.Model
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public DateTime ExperationDate { get; set; }

        public float? Price { get; set; }

        public float? KGPrice { get; set; }

        public long TypeId { get; set; }

        public ProductType Type { get; set; }
    }
}
