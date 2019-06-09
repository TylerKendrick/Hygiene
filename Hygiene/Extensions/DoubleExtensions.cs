using System;

namespace Hygiene
{
    /// <summary>
    /// Provides common operations for a <see cref="double"/> sanitizer
    /// as extension methods for syntactic sugar.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Returns the larger of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The second of two double-precision floating-point numbers to compare.</param>
        /// <returns>
        /// Parameter <paramref name="self"/> or <paramref name="comparable"/>, whichever is larger. 
        /// If <paramref name="self"/>, <paramref name="comparable"/>, or both <paramref name="self"/> and
        /// <paramref name="comparable"/> are equal to <see cref="Double.NaN"/>, <see cref="Double.NaN"/> is returned.
        /// </returns>
        public static ISanitizerTypeBuilder<double> Max(
            this ISanitizerTypeBuilder<double> self,
            double comparable) => self.Transform(
                x => Math.Max(x, comparable));

        /// <summary>
        /// Returns the smaller of two double-precision floating-point numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The second of two double-precision floating-point numbers to compare.</param>
        /// <returns>
        /// Parameter <paramref name="self"/> or <paramref name="comparable"/>, whichever is smaller. 
        /// If <paramref name="self"/>, <paramref name="comparable"/>, or both <paramref name="self"/> and
        /// <paramref name="comparable"/> are equal to  <see cref="Double.NaN"/>,  <see cref="Double.NaN"/> is returned.
        /// </returns>
        public static ISanitizerTypeBuilder<double> Min(
            this ISanitizerTypeBuilder<double> self,
            double comparable) => self.Transform(
                x => Math.Min(x, comparable));

        /// <summary>
        /// Calculates the square root of a double-precision floating-point number.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>The square root of the provided double-precision floating-point number.</returns>
        public static ISanitizerTypeBuilder<double> Sqrt(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Sqrt(x));

        /// <summary>
        /// Returns a specified number raised to the specified power.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="power">A double-precision floating-point number that specifies a power.</param>
        /// <returns>The number x raised to the power y.</returns>
        public static ISanitizerTypeBuilder<double> Pow(
            this ISanitizerTypeBuilder<double> self,
            int power) => self.Transform(
                x => Math.Pow(x, power));

        /// <summary>
        /// Returns the largest integer less than or equal to the specified double-precision
        /// floating-point number.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        /// The largest integer less than or equal to d. If d is equal to  <see cref="Double.NaN"/>,
        /// <seealso cref="Double.NegativeInfinity"/>, or <seealso cref="Double.PositiveInfinity"/>, that value
        /// is returned.
        /// </returns>
        public static ISanitizerTypeBuilder<double> Floor(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Floor(x));

        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified
        /// double-precision floating-point number.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        /// The smallest integral value that is greater than or equal to a. If a is equal
        /// to  <see cref="Double.NaN"/>, <seealso cref="Double.NegativeInfinity"/>, or <seealso cref="Double.PositiveInfinity"/>,
        /// that value is returned. Note that this method returns a <seealso cref="double"/> instead
        /// of an integral type.
        /// </returns>
        public static ISanitizerTypeBuilder<double> Ceiling(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Ceiling(x));

        /// <summary>
        /// Rounds a double-precision floating-point value to a specified number of fractional
        /// digits. A parameter specifies how to round the value if it is midway between
        /// two numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="digits">The number of fractional digits in the return value.</param>
        /// <param name="midpointRounding">Specification for how to round value if it is midway between two other numbers.</param>
        /// <returns>
        /// The number nearest to value that has a number of fractional digits equal to digits.
        /// If value has fewer fractional digits than digits, value is returned unchanged.
        /// </returns>
        public static ISanitizerTypeBuilder<double> Round(
            this ISanitizerTypeBuilder<double> self,
            int digits, MidpointRounding midpointRounding)
            => self.Transform(x => Math.Round(x, digits, midpointRounding));

        /// <summary>
        /// Removes fractional digits from a double-precision floating-point value.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>The digits from a double-precision floating-point value.</returns>
        public static ISanitizerTypeBuilder<double> Truncate(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Truncate(x));
    }
}