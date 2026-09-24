using System.Text.Json.Serialization;

namespace Forge.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ForgeResponseCode
    {
        ArgumentInvalid,
        ArgumentsMissing,
        ClassDefinitionMissing,
        DocumentationDefinitionMissing,
        Error,
        FileExists,
        FileMissing,
        FunctionDefinitionMissing,
        Incomplete,
        RequestNotProcessable,
        ResponseCouldNotBeParsed,
        Success,
        VerbMissing,
        VerbNotRecognized
    }
}
