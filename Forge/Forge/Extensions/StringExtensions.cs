using System.Text.RegularExpressions;

namespace FunctionLibrary.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidHashCode(this string value)
        {
            return true;
        }

        public static string StripCommentMarkers(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var lines = input.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = Regex.Replace(lines[i], @"^\s*(///|//)\s?", "");
            }

            return string.Join(System.Environment.NewLine, lines).Trim();
        }
    }
}