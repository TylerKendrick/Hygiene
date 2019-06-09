using System;

namespace Hygiene
{
    /// <summary>
    /// Provides common operations for a <see cref="TimeSpan"/> sanitizer
    /// as extension methods for syntactic sugar.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        ///     Returns a new <see cref="TimeSpan"/> object whose value is the sum of the specified
        ///     <see cref="TimeSpan"/> object and this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">The time interval to add.</param>
        /// <returns>A new object that represents the value of this instance plus the value of <paramref name="value"/>.</returns>
        public static ISanitizerTypeBuilder<TimeSpan> Add(
            this ISanitizerTypeBuilder<TimeSpan> self,
            TimeSpan value) => self.Transform(x => x.Add(value));

        /// <summary>
        ///     Returns a new <see cref="TimeSpan"/> object whose value is the difference between the
        ///     specified <see cref="TimeSpan"/> object and this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">The time interval to be subtracted.</param>
        /// <returns>
        /// A new time interval whose value is the result of the value of this instance minus
        /// the value of <param name="value"/>.
        /// </returns>
        public static ISanitizerTypeBuilder<TimeSpan> Subtract(
            this ISanitizerTypeBuilder<TimeSpan> self,
            TimeSpan value) => self.Transform(x => x.Subtract(value));

        /// <summary>
        ///     Returns a new <see cref="TimeSpan"/> object whose value is the negated value of this
        ///     instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        /// A new object with the same numeric value as this instance, but with the opposite
        /// sign.
        /// </returns>
        public static ISanitizerTypeBuilder<TimeSpan> Negate(
            this ISanitizerTypeBuilder<TimeSpan> self)
            => self.Transform(x => x.Negate());
    }
}