namespace Hygiene.Tests
{
    public class ClassWithoutSetter
    {
        public string Value => PrivateSetter;
        public string PrivateSetter { get; }

        public ClassWithoutSetter(string value) => PrivateSetter = value;
    }
}