namespace Forge.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSimpleType(this Type type)
        {
            return
                type.IsPrimitive ||
                type == typeof(string) ||
                type == typeof(object) ||
                type == typeof(decimal) ||
                type == typeof(DateTime) ||
                type == typeof(Guid);
        }
    }
}
