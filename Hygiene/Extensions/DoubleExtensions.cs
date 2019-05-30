using System;

namespace Hygiene
{
    public static class DoubleExtensions
    {
        public static ISanitizerTypeBuilder<double> Max(
            this ISanitizerTypeBuilder<double> self,
            double comparable) => self.Transform(
                x => Math.Max(x, comparable));

        public static ISanitizerTypeBuilder<double> Min(
            this ISanitizerTypeBuilder<double> self,
            double comparable) => self.Transform(
                x => Math.Min(x, comparable));

        public static ISanitizerTypeBuilder<double> Sqrt(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Sqrt(x));

        public static ISanitizerTypeBuilder<double> Pow(
            this ISanitizerTypeBuilder<double> self,
            int power) => self.Transform(
                x => Math.Pow(x, power));

        public static ISanitizerTypeBuilder<double> Floor(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Floor(x));

        public static ISanitizerTypeBuilder<double> Ceiling(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Ceiling(x));

        public static ISanitizerTypeBuilder<double> Round(
            this ISanitizerTypeBuilder<double> self,
            int digits, MidpointRounding midpointRounding)
            => self.Transform(x => Math.Round(x, digits, midpointRounding));

        public static ISanitizerTypeBuilder<double> Truncate(
            this ISanitizerTypeBuilder<double> self)
            => self.Transform(x => Math.Truncate(x));
    }
}