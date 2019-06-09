using System;

namespace Hygiene
{
    /// <summary>
    /// Provides common operations for a <see cref="float"/> sanitizer
    /// as extension methods for syntactic sugar.
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Returns the larger of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The second of two single-precision floating-point numbers to compare.</param>
        /// <returns>
        /// Parameter <paramref name="self"/> or <paramref name="comparable"/>, whichever is larger.
        /// If <paramref name="self"/>, or <paramref name="comparable"/>, or both <paramref name="self"/> and
        /// <paramref name="comparable"/> are equal to <see cref="float.NaN"/>, <see cref="float.NaN"/> is returned.
        /// </returns>
        public static ISanitizerTypeBuilder<float> Max(
            this ISanitizerTypeBuilder<float> self,
            float comparable) => self.Transform(
                x => Math.Max(x, comparable));

        /// <summary>
        /// Returns the smaller of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="comparable">The second of two single-precision floating-point numbers to compare.</param>
        /// <returns>
        /// Parameter <paramref name="self"/> or <paramref name="comparable"/>, whichever is smaller. 
        /// If <paramref name="self"/>, <paramref name="comparable"/>, or both <paramref name="self"/> and
        /// <paramref name="comparable"/> are equal to <see cref="float.NaN"/>, <see cref="float.NaN"/> is returned.
        /// </returns>
        public static ISanitizerTypeBuilder<float> Min(
            this ISanitizerTypeBuilder<float> self,
            float comparable) => self.Transform(
                x => Math.Min(x, comparable));
    }
}