using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hygiene
{
    public static class DateTimeExtensions
    {
        public static ISanitizerTypeBuilder<System.DateTime> Add(
            this ISanitizerTypeBuilder<System.DateTime> self,
            System.TimeSpan value) => self.Transform(
                (ref System.DateTime x) => x = x.Add(value));

        public static ISanitizerTypeBuilder<System.DateTime> Subtract(
            this ISanitizerTypeBuilder<System.DateTime> self,
            System.TimeSpan value) => self.Transform((ref System.DateTime x)
                => x = x.Subtract(value));

        public static ISanitizerTypeBuilder<System.DateTime> ToLocalTime(
            this ISanitizerTypeBuilder<System.DateTime> self)
            => self.Transform((ref System.DateTime x)
                => x = x.ToLocalTime());

        public static ISanitizerTypeBuilder<System.DateTime> ToUniversalTime(
            this ISanitizerTypeBuilder<System.DateTime> self)
            => self.Transform((ref System.DateTime x)
                => x = x.ToUniversalTime());

        public static ISanitizerTypeBuilder<System.DateTime> AddYears(
            this ISanitizerTypeBuilder<System.DateTime> self,
            int value) => self.Transform((ref System.DateTime x)
                => x = x.AddYears(value));

        public static ISanitizerTypeBuilder<System.DateTime> AddMonths(
            this ISanitizerTypeBuilder<System.DateTime> self,
            int value) => self.Transform((ref System.DateTime x)
                => x = x.AddMonths(value));

        public static ISanitizerTypeBuilder<System.DateTime> AddDays(
            this ISanitizerTypeBuilder<System.DateTime> self,
            double value) => self.Transform((ref System.DateTime x)
                => x = x.AddDays(value));

        public static ISanitizerTypeBuilder<System.DateTime> AddHours(
            this ISanitizerTypeBuilder<System.DateTime> self,
            double value) => self.Transform((ref System.DateTime x)
                => x = x.AddHours(value));

        public static ISanitizerTypeBuilder<System.DateTime> AddMinutes(
            this ISanitizerTypeBuilder<System.DateTime> self,
            double value) => self.Transform((ref System.DateTime x)
                => x = x.AddMinutes(value));

        public static ISanitizerTypeBuilder<System.DateTime> AddSeconds(
            this ISanitizerTypeBuilder<System.DateTime> self,
            double value) => self.Transform((ref System.DateTime x)
                => x = x.AddSeconds(value));

        public static ISanitizerTypeBuilder<System.DateTime> AddMilliseconds(
            this ISanitizerTypeBuilder<System.DateTime> self,
            double value) => self.Transform((ref System.DateTime x)
                => x = x.AddMilliseconds(value));

        public static ISanitizerTypeBuilder<System.DateTime> AddTicks(
            this ISanitizerTypeBuilder<System.DateTime> self,
            long value) => self.Transform((ref System.DateTime x)
                => x = x.AddTicks(value));
    }
}