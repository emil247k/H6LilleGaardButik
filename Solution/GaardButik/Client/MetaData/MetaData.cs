using GaardButik.Shared;
using System.Reflection;

namespace GaardButik.Client.MetaData
{
    public abstract class MetaData<Type> : IMetaData<Type>
    {
        public System.Type MetaDataType { get => typeof(Type);}

        public virtual PropertyInfo SelectionProperty { get => GetPropertyInfo("Id"); }

        public virtual Dictionary<PropertyInfo, string> GetPropertyDisplayValues()
        {
            throw new NotImplementedException();
        }

        public virtual Dictionary<PropertyInfo, string> GetSelectedPropertys()
        {
            throw new NotImplementedException();
        }

        public PropertyInfo GetPropertyInfo(string property)
        {
            var test = MetaDataType.GetProperty(property);
            if(test == null)
            {
                throw new SystemException("unhandled metadata");
            }
            else 
            { 
                return test; 
            }
        }

    }
}
