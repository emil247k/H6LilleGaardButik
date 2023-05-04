namespace GaardButik.Server.Model
{
    public class Tilbud : Entity
    {
        public ProductType Type { get; set; }

        public float Price { get; set; }

        public long Amount { get; set; }
    }
}
