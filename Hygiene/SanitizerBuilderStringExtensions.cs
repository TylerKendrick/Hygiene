using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hygiene
{
    public static class SanitizerBuilderStringExtensions
    {
        public static ISanitizerTypeBuilder<string> Trim(
            this ISanitizerTypeBuilder<string> self,
            params char[] trimChars)
            => self.Transform((ref string x) =>
            {
                x = trimChars?.Any() == true
                    ? x.Trim(trimChars) : x.Trim();
            });

        public static ISanitizerTypeBuilder<string> ToUpper(
            this ISanitizerTypeBuilder<string> self,
            CultureInfo cultureInfo = null)
            => self.Transform((ref string x) =>
            {
                x = cultureInfo == null
                    ? x.ToUpper() : x.ToUpper(cultureInfo);
            });

        public static ISanitizerTypeBuilder<string> ToLower(
            this ISanitizerTypeBuilder<string> self,
            CultureInfo cultureInfo = null)
            => self.Transform((ref string x) =>
            {
                x = cultureInfo == null
                    ? x.ToLower() : x.ToLower(cultureInfo);
            });

        public static ISanitizerTypeBuilder<string> Replace(
            this ISanitizerTypeBuilder<string> self,
            string pattern, string replacement)
            => self.Transform((ref string x)
                => x = Regex.Replace(x, pattern, replacement));
    }
}