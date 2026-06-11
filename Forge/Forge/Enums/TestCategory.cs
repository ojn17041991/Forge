using System.ComponentModel;

namespace Forge.Enums
{
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
