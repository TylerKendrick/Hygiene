namespace Hygiene
{
    public static class FloatExtensions
    {
        public static ISanitizerTypeBuilder<float> Max(
            this ISanitizerTypeBuilder<float> self,
            float comparable) => self.Transform((ref float x) =>
                x = System.Math.Max(x, comparable));

        public static ISanitizerTypeBuilder<float> Min(
            this ISanitizerTypeBuilder<float> self,
            float comparable) => self.Transform((ref float x) =>
                x = System.Math.Min(x, comparable));
    }
}