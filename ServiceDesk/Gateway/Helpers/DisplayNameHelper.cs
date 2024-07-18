using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
namespace Gateway.Helpers
{
public static class DisplayNameHelper
{
    public static string GetDisplayName(Type modelType, string propertyName)
        {
            var property = modelType.GetProperty(propertyName);
            if (property == null) return propertyName;

            var displayNameAttr = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                                          .FirstOrDefault() as DisplayNameAttribute;

            return displayNameAttr != null ? displayNameAttr.DisplayName : propertyName;
        }
}
}