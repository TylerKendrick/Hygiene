using System;

namespace Hygiene
{
    /// <summary>
    /// Provides common operations for a <see cref="DateTime"/> sanitizer
    /// as extension methods for syntactic sugar.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the value of the specified <seealso cref="TimeSpan"/>
        /// to the value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the time interval represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> Add(
            this ISanitizerTypeBuilder<DateTime> self,
            TimeSpan value) => self.Transform(x => x.Add(value));

        /// <summary>
        /// Subtracts the specified duration from this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">The time interval to subtract.</param>
        /// <returns>
        /// An object that is equal to the date and time represented by this instance minus
        /// the time interval represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> Subtract(
            this ISanitizerTypeBuilder<DateTime> self,
            TimeSpan value) => self.Transform(x => x.Subtract(value));

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to local time.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        ///     An object whose <see cref="DateTime.Kind"/> property is <see cref="DateTimeKind.Local"/>, and
        ///     whose value is the local time equivalent to the value of the current <see cref="DateTime"/>
        ///     object, or <see cref="DateTime.MaxValue"/> if the converted value is too large to be
        ///     represented by a <see cref="DateTime"/> object, or <see cref="DateTime.MinValue"/> if the converted
        ///     value is too small to be represented as a <see cref="DateTime"/> object.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> ToLocalTime(
            this ISanitizerTypeBuilder<DateTime> self)
            => self.Transform(x => x.ToLocalTime());

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to Coordinated Universal
        /// Time (UTC).
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <returns>
        ///     An object whose <see cref="DateTime.Kind"/> property is <see cref="DateTimeKind.Utc"/>, and
        ///     whose value is the UTC equivalent to the value of the current <see cref="DateTime"/>
        ///     object, or <see cref="DateTime.MaxValue"/> if the converted value is too large to be
        ///     represented by a <see cref="DateTime"/> object, or <see cref="DateTime.MinValue"/> if the converted
        ///     value is too small to be represented by a <see cref="DateTime"/> object.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> ToUniversalTime(
            this ISanitizerTypeBuilder<DateTime> self)
            => self.Transform(x => x.ToUniversalTime());

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of years to the
        /// value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>
        ///     An object whose value is the sum of the date and time represented by this instance
        ///     and the number of years represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddYears(
            this ISanitizerTypeBuilder<DateTime> self,
            int value) => self.Transform(x => x.AddYears(value));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of months to the
        /// value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and months.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddMonths(
            this ISanitizerTypeBuilder<DateTime> self,
            int value) => self.Transform(x => x.AddMonths(value));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of days to the value
        /// of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">
        /// A number of whole and fractional days. The value parameter can be negative or
        /// positive.
        /// </param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of days represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddDays(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddDays(value));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of hours to the
        /// value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">
        /// A number of whole and fractional hours. The value parameter can be negative or
        /// positive.
        /// </param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of hours represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddHours(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddHours(value));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of minutes to the
        /// value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">
        /// A number of whole and fractional minutes. The value parameter can be negative
        /// or positive.
        /// </param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of minutes represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddMinutes(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddMinutes(value));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of seconds to the
        /// value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">
        /// A number of whole and fractional seconds. The value parameter can be negative
        /// or positive.
        /// </param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of seconds represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddSeconds(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddSeconds(value));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of milliseconds
        /// to the value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">
        /// A number of whole and fractional milliseconds. The value parameter can be negative
        /// or positive. Note that this value is rounded to the nearest integer.
        /// </param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of milliseconds represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddMilliseconds(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddMilliseconds(value));

        /// <summary>
        /// Returns a new <see cref="DateTime"/> that adds the specified number of ticks to the
        /// value of this instance.
        /// </summary>
        /// <param name="self">The builder instance.</param>
        /// <param name="value">A number of 100-nanosecond ticks. The value parameter can be positive or negative.</param>
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the time represented by value.
        /// </returns>
        public static ISanitizerTypeBuilder<DateTime> AddTicks(
            this ISanitizerTypeBuilder<DateTime> self,
            long value) => self.Transform(x => x.AddTicks(value));
    }
}