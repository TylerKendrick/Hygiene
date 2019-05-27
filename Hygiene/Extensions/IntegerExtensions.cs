namespace Hygiene
{
    public static class IntegerExtensions
    {
        public static ISanitizerTypeBuilder<int> Max(
            this ISanitizerTypeBuilder<int> self,
            int comparable) => self.Transform((ref int x) =>
                x = System.Math.Max(x, comparable));

        public static ISanitizerTypeBuilder<int> Min(
            this ISanitizerTypeBuilder<int> self,
            int comparable) => self.Transform((ref int x) =>
                x = System.Math.Min(x, comparable));

        public static ISanitizerTypeBuilder<int> Abs(
            this ISanitizerTypeBuilder<int> self)
            => self.Transform((ref int x) =>
                x = System.Math.Abs(x));
    }
}