using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaardButik.Shared
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime ExperationDate { get; set; }
        public float? Price { get; set; }
        public float? KGPrice { get; set; }
        public ProductType Type { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

    }
}
