using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Forge.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TestCategory
    {
        [Description("all")]
        All,

        [Description("essential")]
        Essential,

        [Description("valuable")]
        Valuable,

        [Description("optional")]
        Optional
    }
}
