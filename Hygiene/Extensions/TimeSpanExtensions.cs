using System;

namespace Hygiene
{
    public static class TimeSpanExtensions
    {
        public static ISanitizerTypeBuilder<TimeSpan> Add(
            this ISanitizerTypeBuilder<TimeSpan> self,
            TimeSpan value) => self.Transform(x => x.Add(value));

        public static ISanitizerTypeBuilder<TimeSpan> Subtract(
            this ISanitizerTypeBuilder<TimeSpan> self,
            TimeSpan value) => self.Transform(x => x.Subtract(value));

        public static ISanitizerTypeBuilder<TimeSpan> Negate(
            this ISanitizerTypeBuilder<TimeSpan> self)
            => self.Transform(x => x.Negate());
    }
}