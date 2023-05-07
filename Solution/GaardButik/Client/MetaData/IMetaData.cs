using System.Reflection;

namespace GaardButik.Client.MetaData
{
    public interface IMetaData<MetaType>
    {
        public Type MetaDataType { get;}

        public PropertyInfo SelectionProperty { get; }

        public Dictionary<PropertyInfo, string> GetPropertyDisplayValues();

        public Dictionary<PropertyInfo, string> GetSelectedPropertys();
    }
}
