using GaardButik.Shared;
using System.Linq;
using System.Reflection;

namespace GaardButik.Client.MetaData
{
    public class ProductMetaData : MetaData<Product>
    {
        public override Dictionary<PropertyInfo, string> GetPropertyDisplayValues()
        {
            var displayNames = new Dictionary<PropertyInfo, string> {
                { GetPropertyInfo("Name"), "Navn" },
                { GetPropertyInfo("ExperationDate"), "Udløbsdato" },
                { GetPropertyInfo("Price"), "Pris" },
                { GetPropertyInfo("KGPrice"), "Kilo pris" },
                { GetPropertyInfo("TypeName"), "Type navn" },
                { GetPropertyInfo("TypeDescription"), "beskrivelse" },
            };
            return displayNames;
        }

        public override Dictionary<PropertyInfo, string> GetSelectedPropertys()
        {
            var selected = new List<PropertyInfo>()
            {
                GetPropertyInfo("Name"),
                GetPropertyInfo("TypeDescription"),
                GetPropertyInfo("Price"),
                GetPropertyInfo("ExperationDate")
            };
            return GetPropertyDisplayValues().Where(x => selected.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}