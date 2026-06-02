using System.ComponentModel;

namespace Forge.Commands.Enums
{
    public enum CommandVerb
    {
        [Description("spec")]
        Spec,

        [Description("refine")]
        Refine,

        [Description("gen")]
        Gen
    }
}
