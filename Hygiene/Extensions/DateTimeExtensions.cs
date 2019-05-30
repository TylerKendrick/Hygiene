using System;

namespace Hygiene
{
    public static class DateTimeExtensions
    {
        public static ISanitizerTypeBuilder<DateTime> Add(
            this ISanitizerTypeBuilder<DateTime> self,
            TimeSpan value) => self.Transform(x => x.Add(value));

        public static ISanitizerTypeBuilder<DateTime> Subtract(
            this ISanitizerTypeBuilder<DateTime> self,
            TimeSpan value) => self.Transform(x => x.Subtract(value));

        public static ISanitizerTypeBuilder<DateTime> ToLocalTime(
            this ISanitizerTypeBuilder<DateTime> self)
            => self.Transform(x => x.ToLocalTime());

        public static ISanitizerTypeBuilder<DateTime> ToUniversalTime(
            this ISanitizerTypeBuilder<DateTime> self)
            => self.Transform(x => x.ToUniversalTime());

        public static ISanitizerTypeBuilder<DateTime> AddYears(
            this ISanitizerTypeBuilder<DateTime> self,
            int value) => self.Transform(x => x.AddYears(value));

        public static ISanitizerTypeBuilder<DateTime> AddMonths(
            this ISanitizerTypeBuilder<DateTime> self,
            int value) => self.Transform(x => x.AddMonths(value));

        public static ISanitizerTypeBuilder<DateTime> AddDays(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddDays(value));

        public static ISanitizerTypeBuilder<DateTime> AddHours(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddHours(value));

        public static ISanitizerTypeBuilder<DateTime> AddMinutes(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddMinutes(value));

        public static ISanitizerTypeBuilder<DateTime> AddSeconds(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddSeconds(value));

        public static ISanitizerTypeBuilder<DateTime> AddMilliseconds(
            this ISanitizerTypeBuilder<DateTime> self,
            double value) => self.Transform(x => x.AddMilliseconds(value));

        public static ISanitizerTypeBuilder<DateTime> AddTicks(
            this ISanitizerTypeBuilder<DateTime> self,
            long value) => self.Transform(x => x.AddTicks(value));
    }
}