using System.ComponentModel;
using System.Reflection;

namespace Forge.Extensions
{
    public static class EnumExtensions
    {
        public static string? ToDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return null;
            }

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description;
        }

        public static T? ToEnum<T>(this string value) where T : struct, Enum
        {
            foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attribute = field.GetCustomAttribute<DescriptionAttribute>();

                if (attribute != null && attribute.Description == value)
                {
                    return (T)field.GetValue(null)!;
                }
            }

            return null;
        }
    }
}
