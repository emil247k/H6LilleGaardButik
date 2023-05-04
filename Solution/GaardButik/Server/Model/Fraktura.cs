namespace GaardButik.Server.Model
{
    public class Fraktura : Entity
    {
        public DateTime Date { get; set; }

        public ICollection<FrakturaProduct> Products { get; } = new List<FrakturaProduct>();
    }
}
