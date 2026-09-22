using System.Text.Json;

namespace Forge.Utilities
{
    public static class JsonSerializerOptionsProvider
    {
        public static JsonSerializerOptions Options { get; } = new JsonSerializerOptions
        {
            WriteIndented = true
        };
    }
}
