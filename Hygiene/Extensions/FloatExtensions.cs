using System;

namespace Hygiene
{
    public static class FloatExtensions
    {
        public static ISanitizerTypeBuilder<float> Max(
            this ISanitizerTypeBuilder<float> self,
            float comparable) => self.Transform(
                x => Math.Max(x, comparable));

        public static ISanitizerTypeBuilder<float> Min(
            this ISanitizerTypeBuilder<float> self,
            float comparable) => self.Transform(
                x => Math.Min(x, comparable));
    }
}