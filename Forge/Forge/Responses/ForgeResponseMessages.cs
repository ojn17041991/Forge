using Forge.Enums;

namespace Forge.Responses
{
    public static class ForgeResponseMessages
    {
        /// <summary>
        /// Gets a message for console output based on an internal response code.
        /// </summary>
        /// <param name="responseCode">The response code indicating the current operation state.</param>
        /// <returns>A human-readable console message.</returns>
        public static string Get(ForgeResponseCode responseCode)
        {
            return responseCode switch
            {
                ForgeResponseCode.ArgumentInvalid => "invalid argument",
                ForgeResponseCode.ArgumentsMissing => "missing command arguments",
                ForgeResponseCode.Error => "internal error",
                ForgeResponseCode.FileExists => "file exists",
                ForgeResponseCode.FileMissing => "missing file",
                ForgeResponseCode.Success => "command executed",
                ForgeResponseCode.VerbMissing => "missing command",
                ForgeResponseCode.VerbNotRecognized => "unrecognized command",
                _ => "unknown error"
            };
        }
    }
}
