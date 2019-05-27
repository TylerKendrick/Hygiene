namespace Hygiene
{
    public static class TimeSpanExtensions
    {
        public static ISanitizerTypeBuilder<System.TimeSpan> Add(
            this ISanitizerTypeBuilder<System.TimeSpan> self,
            System.TimeSpan value) => self.Transform(
                (ref System.TimeSpan x) => x = x.Add(value));

        public static ISanitizerTypeBuilder<System.TimeSpan> Subtract(
            this ISanitizerTypeBuilder<System.TimeSpan> self,
            System.TimeSpan value) => self.Transform(
                (ref System.TimeSpan x) => x = x.Subtract(value));

        public static ISanitizerTypeBuilder<System.TimeSpan> Negate(
            this ISanitizerTypeBuilder<System.TimeSpan> self)
            => self.Transform((ref System.TimeSpan x) => x = x.Negate());
    }
}