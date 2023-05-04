namespace GaardButik.Server.Model
{
    public class FrakturaProduct : Entity
    {
        public long FrakturaId { get; set; }

        public Fraktura Fraktura { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }
    }
}
