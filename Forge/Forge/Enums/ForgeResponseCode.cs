using System.Text.Json.Serialization;

namespace Forge.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ForgeResponseCode
    {
        ArgumentInvalid,
        ArgumentsMissing,
        Error,
        FileExists,
        FileMissing,
        Incomplete,
        RequestNotProcessable,
        ResponseUnparsable,
        Success,
        VerbMissing,
        VerbNotRecognized
    }
}
