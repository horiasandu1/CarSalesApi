using System;

namespace Utils
{
    /// <summary>
    /// This class copies all attributes from one class to the other.
    /// You must indicate the source (parent) and destination (child) types.
    /// See console project attached for example usage.
    /// Code obtained from:
    /// https://www.pluralsight.com/guides/property-copying-between-two-objects-using-reflection
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    /// <typeparam name="TChild"></typeparam>
    public class PropertyCopier<TParent, TChild> where TParent : class where TChild : class
    {
        public static void Copy(TParent parent, TChild child, bool ignoreSubType = false)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name)
                    {
                        if (((parentProperty.PropertyType.FullName.Contains(childProperty.PropertyType.Name)
                        || childProperty.PropertyType.FullName.Contains(parentProperty.PropertyType.Name)) && ignoreSubType)
                        || (parentProperty.PropertyType == childProperty.PropertyType))
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent));
                            break;
                        }
                    }
                }
            }
        }
    }
}
