using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hygiene
{
    /// <summary>
    /// Adds string specific mutations common to string sanitization.
    /// </summary>
    public static class SanitizerBuilderStringExtensions
    {
        /// <summary>
        /// Concatenates two <see cref="System.String"/> values.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="value">The value to concatenate.</param>
        /// <returns>The concatenated results.</returns>
        public static ISanitizerTypeBuilder<string> Add(
            this ISanitizerTypeBuilder<string> self,
            string value) => self.Transform(
                (ref string x) => x += value);

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
        ///     Removes all leading occurrences of a set of characters specified
        ///     in an array from the current System.String object.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>
        ///     The string that remains after all occurrences of the characters in the trimChars
        ///     parameter are removed from the start of the current string. If trimChars
        ///     is null or an empty array, white-space characters are removed instead. If no
        ///     characters can be trimmed from the current instance, the method returns the current
        ///     instance unchanged.
        /// </returns>
        public static ISanitizerTypeBuilder<string> TrimStart(
            this ISanitizerTypeBuilder<string> self,
            params char[] trimChars)
            => self.Transform((ref string x) =>
            {
                x = trimChars?.Any() == true
                    ? x.TrimStart(trimChars) : x.TrimStart();
            });

        /// <summary>
        ///     Removes all trailing occurrences of a set of characters specified
        ///     in an array from the current System.String object.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>
        ///     The string that remains after all occurrences of the characters in the trimChars
        ///     parameter are removed from the end of the current string. If trimChars
        ///     is null or an empty array, white-space characters are removed instead. If no
        ///     characters can be trimmed from the current instance, the method returns the current
        ///     instance unchanged.
        /// </returns>
        public static ISanitizerTypeBuilder<string> TrimEnd(
            this ISanitizerTypeBuilder<string> self,
            params char[] trimChars)
            => self.Transform((ref string x) =>
            {
                x = trimChars?.Any() == true
                    ? x.TrimEnd(trimChars) : x.TrimEnd();
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

        /// <summary>
        ///     Retrieves a substring from this instance. The substring starts at a specified
        ///     character position and continues to the end of the string.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>
        ///     A string that is equivalent to the substring that begins at startIndex in this
        ///     instance, or System.String.Empty if startIndex is equal to the length of this
        ///     instance.
        /// </returns>
        public static ISanitizerTypeBuilder<string> Substring(
            this ISanitizerTypeBuilder<string> self,
            int startIndex, int? length = null)
            => self.Transform((ref string x)
                => x = length == null
                ? x.Substring(startIndex)
                : x.Substring(startIndex, length.Value));

        /// <summary>
        ///     Returns a new string in which a specified number of characters in the current
        ///     instance beginning at a specified position have been deleted.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="startIndex">The zero-based position to begin deleting characters.</param>
        /// <param name="count">The number of characters to delete.</param>
        /// <returns>A new string that is equivalent to this instance except for the removed characters.</returns>
        public static ISanitizerTypeBuilder<string> Remove(
            this ISanitizerTypeBuilder<string> self,
            int startIndex, int? count = null)
            => self.Transform((ref string x)
                => x = count == null
                ? x.Remove(startIndex)
                : x.Remove(startIndex, count.Value));

        /// <summary>
        ///     Returns a new string whose textual value is the same as this string, but whose
        ///     binary representation is in the specified Unicode normalization form.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="normalizationForm">A Unicode normalization form.</param>
        /// <returns>
        ///     A new string whose textual value is the same as this string, but whose binary
        ///     representation is in the normalization form specified by the normalizationForm
        ///     parameter.
        /// </returns>
        public static ISanitizerTypeBuilder<string> Normalize(
            this ISanitizerTypeBuilder<string> self,
            NormalizationForm? normalizationForm = null)
            => self.Transform((ref string x)
                => x = normalizationForm == null
                ? x.Normalize()
                : x.Normalize(normalizationForm.Value));

        /// <summary>
        ///     Returns a new string that right-aligns the characters in this instance by padding
        ///     them on the left with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="totalWidth">
        ///     The number of characters in the resulting string, equal to the number of original
        ///     characters plus any additional padding characters.
        /// </param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns>
        ///     A new string that is equivalent to this instance, but right-aligned and padded
        ///     on the left with as many paddingChar characters as needed to create a length
        ///     of totalWidth. However, if totalWidth is less than the length of this instance,
        ///     the method returns a reference to the existing instance. If totalWidth is equal
        ///     to the length of this instance, the method returns a new string that is identical
        ///     to this instance.
        /// </returns>
        public static ISanitizerTypeBuilder<string> PadLeft(
            this ISanitizerTypeBuilder<string> self,
            int totalWidth, char? paddingChar = null)
            => self.Transform((ref string x)
                => x = paddingChar == null
                ? x.PadLeft(totalWidth)
                : x.PadLeft(totalWidth, paddingChar.Value));

        /// <summary>
        ///     Returns a new string that left-aligns the characters in this string by padding
        ///     them on the right with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="self">The target instance for mutation.</param>
        /// <param name="totalWidth">
        ///     The number of characters in the resulting string, equal to the number of original
        ///     characters plus any additional padding characters.
        /// </param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns>
        ///     A new string that is equivalent to this instance, but left-aligned and padded
        ///     on the right with as many paddingChar characters as needed to create a length
        ///     of totalWidth. However, if totalWidth is less than the length of this instance,
        ///     the method returns a reference to the existing instance. If totalWidth is equal
        ///     to the length of this instance, the method returns a new string that is identical
        ///     to this instance.
        /// </returns>
        public static ISanitizerTypeBuilder<string> PadRight(
            this ISanitizerTypeBuilder<string> self,
            int totalWidth, char? paddingChar = null)
            => self.Transform((ref string x)
                => x = paddingChar == null
                ? x.PadRight(totalWidth)
                : x.PadRight(totalWidth, paddingChar.Value));
    }
}