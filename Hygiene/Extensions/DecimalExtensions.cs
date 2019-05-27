namespace Hygiene
{
    public static class DecimalExtensions
    {
        public static ISanitizerTypeBuilder<decimal> Max(
            this ISanitizerTypeBuilder<decimal> self,
            decimal comparable) => self.Transform((ref decimal x) =>
                x = System.Math.Max(x, comparable));

        public static ISanitizerTypeBuilder<decimal> Min(
            this ISanitizerTypeBuilder<decimal> self,
            decimal comparable) => self.Transform((ref decimal x) =>
                x = System.Math.Min(x, comparable));

        public static ISanitizerTypeBuilder<decimal> Floor(
            this ISanitizerTypeBuilder<decimal> self)
            => self.Transform((ref decimal x) =>
                x = System.Math.Floor(x));

        public static ISanitizerTypeBuilder<decimal> Ceiling(
            this ISanitizerTypeBuilder<decimal> self)
            => self.Transform((ref decimal x) =>
                x = System.Math.Ceiling(x));

        public static ISanitizerTypeBuilder<decimal> Round(
            this ISanitizerTypeBuilder<decimal> self,
            int digits, System.MidpointRounding midpointRounding)
            => self.Transform((ref decimal x) =>
                x = System.Math.Round(x, digits, midpointRounding));

        public static ISanitizerTypeBuilder<decimal> Truncate(
            this ISanitizerTypeBuilder<decimal> self)
            => self.Transform((ref decimal x) =>
                x = System.Math.Truncate(x));
    }
}