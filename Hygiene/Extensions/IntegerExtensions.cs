using System;

namespace Hygiene
{
    public static class IntegerExtensions
    {
        public static ISanitizerTypeBuilder<int> Max(
            this ISanitizerTypeBuilder<int> self,
            int comparable) => self.Transform(
                x => Math.Max(x, comparable));

        public static ISanitizerTypeBuilder<int> Min(
            this ISanitizerTypeBuilder<int> self,
            int comparable) => self.Transform(
                x => Math.Min(x, comparable));

        public static ISanitizerTypeBuilder<int> Abs(
            this ISanitizerTypeBuilder<int> self)
            => self.Transform(x => Math.Abs(x));
    }
}