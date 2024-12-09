using System.Reflection;

namespace ChurchMS.Infrastructure.Documents.Extensions;

public static class ObjectExtension
{
    public static List<PropertyInfo> GetObjectProperties(this object obj)
    {
        return new List<PropertyInfo>(obj.GetType().GetProperties());
    }

    public static object? GetPropertyValue(this object obj, PropertyInfo prop)
    {
        return prop?.GetValue(obj, null);
    }

    public static bool IsPrimitive(this object obj)
    {
        Type type = obj.GetType();
        if (type.IsPrimitive || type == typeof(decimal) || type == typeof(string) || type == typeof(DBNull))
            return true;

        return false;
    }

    public static Type GetPropertyType(this PropertyInfo prop)
    {
        var propertyType = prop.PropertyType;
        if (propertyType.IsGenericType &&
            propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            return propertyType.GetGenericArguments()[0];

        return propertyType;
    }
}
