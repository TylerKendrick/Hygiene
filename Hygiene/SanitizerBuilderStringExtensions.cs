using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hygiene
{
    /// <summary>
    /// Adds string specific mutations common to string sanitization.
    /// </summary>
    public static class SanitizerBuilderStringExtensions
    {
        /// <summary>
        ///     Removes all leading and trailing occurrences of a set of characters specified
        ///     in an array from the current System.String object.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>
        ///     The string that remains after all occurrences of the characters in the trimChars
        ///     parameter are removed from the start and end of the current string. If trimChars
        ///     is null or an empty array, white-space characters are removed instead. If no
        ///     characters can be trimmed from the current instance, the method returns the current
        ///     instance unchanged.
        /// </returns>
        public static ISanitizerTypeBuilder<string> Trim(
            this ISanitizerTypeBuilder<string> self,
            params char[] trimChars)
            => self.Transform((ref string x) =>
            {
                x = trimChars?.Any() == true
                    ? x.Trim(trimChars) : x.Trim();
            });

        /// <summary>
        ///     Returns a copy of this string converted to uppercase.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="cultureInfo">An object that supplies culture-specific casing rules.</param>
        /// <returns>The uppercase equivalent of the current string.</returns>
        public static ISanitizerTypeBuilder<string> ToUpper(
            this ISanitizerTypeBuilder<string> self,
            CultureInfo cultureInfo = null)
            => self.Transform((ref string x) =>
            {
                x = cultureInfo == null
                    ? x.ToUpper() : x.ToUpper(cultureInfo);
            });

        /// <summary>
        ///     Returns a copy of this string converted to lowercase, using the casing rules
        ///     of the specified culture.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="cultureInfo">An object that supplies culture-specific casing rules.</param>
        /// <returns>The lowercase equivalent of the current string.</returns>
        public static ISanitizerTypeBuilder<string> ToLower(
            this ISanitizerTypeBuilder<string> self,
            CultureInfo cultureInfo = null)
            => self.Transform((ref string x) =>
            {
                x = cultureInfo == null
                    ? x.ToLower() : x.ToLower(cultureInfo);
            });

        /// <summary>
        ///     In a specified input string, replaces all strings that match a specified regular
        ///     expression with a specified replacement string.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns>
        ///     A new string that is identical to the input string, except that the replacement
        ///     string takes the place of each matched string. If pattern is not matched in the
        ///     current instance, the method returns the current instance unchanged.
        /// </returns>
        public static ISanitizerTypeBuilder<string> Replace(
            this ISanitizerTypeBuilder<string> self,
            string pattern, string replacement)
            => self.Transform((ref string x)
                => x = Regex.Replace(x, pattern, replacement));
    }
}