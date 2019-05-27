namespace Hygiene
{
    public static class DoubleExtensions
    {
        public static ISanitizerTypeBuilder<double> Max(
            this ISanitizerTypeBuilder<double> self,
            double comparable) => self.Transform((ref double x) =>
                x = System.Math.Max(x, comparable));

        public static ISanitizerTypeBuilder<double> Min(
            this ISanitizerTypeBuilder<double> self,
            double comparable) => self.Transform((ref double x) =>
                x = System.Math.Min(x, comparable));

        public static ISanitizerTypeBuilder<double> Sqrt(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform((ref double x) =>
                x = System.Math.Sqrt(x));

        public static ISanitizerTypeBuilder<double> Pow(
            this ISanitizerTypeBuilder<double> self,
            int power) => self.Transform((ref double x) =>
                x = System.Math.Pow(x, power));

        public static ISanitizerTypeBuilder<double> Floor(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform((ref double x) =>
                x = System.Math.Floor(x));

        public static ISanitizerTypeBuilder<double> Ceiling(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform((ref double x) =>
                x = System.Math.Ceiling(x));

        public static ISanitizerTypeBuilder<double> Round(
            this ISanitizerTypeBuilder<double> self,
            int digits, System.MidpointRounding midpointRounding)
            => self.Transform((ref double x) =>
                x = System.Math.Round(x, digits, midpointRounding));

        public static ISanitizerTypeBuilder<double> Truncate(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform((ref double x) =>
                x = System.Math.Truncate(x));
    }
}