using System;

namespace Hygiene
{
    /// <summary>
    /// Provides common operations for an <see cref="Int32"/> sanitizer
    /// as extension methods for syntactic sugar.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Returns the larger of two 32-bit signed integers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The 32-bit signed integer to compare.</param>
        /// <returns>Parameter <param name="self"/> or <param name="comparable"/>, whichever is larger.</returns>
        public static ISanitizerTypeBuilder<int> Max(
            this ISanitizerTypeBuilder<int> self,
            int comparable) => self.Transform(
                x => Math.Max(x, comparable));

        /// <summary>
        /// Returns the smaller of two 32-bit signed integers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The 32-bit signed integer to compare.</param>
        /// <returns>Parameter <paramref name="self"/> or <paramref name="comparable"/>, whichever is smaller.</returns>
        public static ISanitizerTypeBuilder<int> Min(
            this ISanitizerTypeBuilder<int> self,
            int comparable) => self.Transform(
                x => Math.Min(x, comparable));

        /// <summary>
        /// Returns the absolute value of a 32-bit signed integer.
        /// <param name="self">The builder instance.</param>
        /// <returns>A 32-bit signed integer, x, such that 0 ≤ x ≤ <see cref="Int32.MaxValue"/>.</returns>
        public static ISanitizerTypeBuilder<int> Abs(
            this ISanitizerTypeBuilder<int> self)
            => self.Transform(x => Math.Abs(x));
    }
}