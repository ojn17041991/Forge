using Forge.Enums;

namespace Forge.Responses
{
    public static class ForgeResponseMessages
    {
        public static string Get(ForgeResponseCode responseCode)
        {
            return responseCode switch
            {
                ForgeResponseCode.Success => "command executed",
                ForgeResponseCode.ArgumentsMissing => "missing command arguments",
                ForgeResponseCode.VerbMissing => "missing command",
                ForgeResponseCode.VerbNotRecognized => "unrecognized command",
                ForgeResponseCode.Error => "internal error",
                _ => "unknown error"
            };
        }
    }
}
