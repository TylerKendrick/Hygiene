using System;

namespace Hygiene
{
    /// <summary>
    /// Provides common operations for a <see cref="decimal"/> sanitizer
    /// as extension methods for syntactic sugar.
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Returns the larger of two decimal numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The second of two decimal numbers to compare.</param>
        /// <returns>Parameter <paramref name="self"/> or <paramref name="comparable"/>, whichever is larger.</returns>
        public static ISanitizerTypeBuilder<decimal> Max(
            this ISanitizerTypeBuilder<decimal> self,
            decimal comparable) => self.Transform(
                x => Math.Max(x, comparable));

        /// <summary>
        /// Returns the smaller of two decimal numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The second of two decimal numbers to compare.</param>
        /// <returns>Parameter <paramref name="self"/> or <paramref name="comparable"/>, whichever is smaller.</returns>
        public static ISanitizerTypeBuilder<decimal> Min(
            this ISanitizerTypeBuilder<decimal> self,
            decimal comparable) => self.Transform(
                x => Math.Min(x, comparable));

        /// <summary>
        /// Returns the largest integer less than or equal to the specified decimal number.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        /// The largest integer less than or equal to d. Note that the method returns an
        /// integral value of type <see cref="Math"/>.
        /// </returns>
        public static ISanitizerTypeBuilder<decimal> Floor(
            this ISanitizerTypeBuilder<decimal> self)
            => self.Transform(x => Math.Floor(x));

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified
        /// decimal number.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        /// The smallest integral value that is greater than or equal to d. Note that this
        /// method returns a <see cref="decimal"/> instead of an integral type.
        /// </returns>
        public static ISanitizerTypeBuilder<decimal> Ceiling(
            this ISanitizerTypeBuilder<decimal> self)
            => self.Transform(x => Math.Ceiling(x));

        /// <summary>
        /// Rounds a decimal value to a specified number of fractional digits. A parameter
        /// specifies how to round the value if it is midway between two numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="digits">The number of decimal places in the return value.</param>
        /// <param name="midpointRounding">Specification for how to round d if it is midway between two other numbers.</param>
        /// <returns>
        /// The number nearest to d that contains a number of fractional digits equal to
        /// decimals. If d has fewer fractional digits than decimals, d is returned unchanged.
        /// </returns>
        public static ISanitizerTypeBuilder<decimal> Round(
            this ISanitizerTypeBuilder<decimal> self,
            int digits, MidpointRounding midpointRounding)
            => self.Transform(x => Math.Round(x, digits, midpointRounding));

        /// <summary>
        /// Calculates the integral part of a specified decimal number.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        /// The integral part of d; that is, the number that remains after any fractional
        /// digits have been discarded.
        /// </returns>
        public static ISanitizerTypeBuilder<decimal> Truncate(
            this ISanitizerTypeBuilder<decimal> self)
            => self.Transform(x => Math.Truncate(x));
    }
}