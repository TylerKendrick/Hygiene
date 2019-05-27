using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hygiene.Tests
{
    [TestClass]
    public class TypeConfigurationSyncTests
    {
        [TestMethod]
        public void SimpleTypeBuilderMeetsExpectations()
        {
            var configuration = new SanitizerConfigurationProvider(builder
                => builder.ForType((ref string input)
                    => input = input.Trim('-')));

            var sanitizer = configuration.CreateSanitizer<string>();
            var result = "--success--";
            sanitizer.Sanitize(ref result);

            Assert.AreEqual("success", result);
        }

        [TestMethod]
        public void ComplexTypeBuilderFailsWithoutSetter()
        {
            var configuration = new SanitizerConfigurationProvider(builder
                => builder.ForType<ClassWithoutSetter>(typeBuilder => typeBuilder
                    .Property(y => y.Value)
                    .Transform((ref string input)
                        => input = input.Replace("-", ""))));

            var sanitizer = configuration.CreateSanitizer<ClassWithoutSetter>();
            var result = new ClassWithoutSetter("555-555-5555");
            var exception = Assert.ThrowsException<ArgumentException>(
                () => sanitizer.Sanitize(ref result));

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void ComplexTypeBuilderFailsWithPrivateSetter()
        {
            var configuration = new SanitizerConfigurationProvider(builder
                => builder.ForType<ClassWithoutSetter>(typeBuilder => typeBuilder
                    .Property(y => y.PrivateSetter)
                    .Transform((ref string input)
                        => input = input.Replace("-", ""))));

            var sanitizer = configuration.CreateSanitizer<ClassWithoutSetter>();
            var result = new ClassWithoutSetter("555-555-5555");
            var exception = Assert.ThrowsException<ArgumentException>(
                () => sanitizer.Sanitize(ref result));

            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void ComplexTypeBuilderMeetsExpectations()
        {
            var configuration = new SanitizerConfigurationProvider(builder
                => builder.ForType<TestClass>(typeBuilder => typeBuilder
                    .Property(y => y.PhoneNumber)
                    .Transform((ref string input)
                        => input = input.Replace("-", ""))));

            var sanitizer = configuration.CreateSanitizer<TestClass>();
            var result = new TestClass
            {
                PhoneNumber = "555-555-5555"
            };
            sanitizer.Sanitize(ref result);

            Assert.AreEqual("5555555555", result.PhoneNumber);
        }

        [TestMethod]
        public void CompositeBuilderMeetsExpectations()
        {
            var configuration = new SanitizerConfigurationProvider(builder
                => builder.ForType<TestClass>(typeBuilder =>
                {
                    var propertyBuilder = typeBuilder
                        .Property(x => x.PhoneNumber)
                        .Transform((ref string input)
                            => input = input.Replace("-", "")).Trim();

                    propertyBuilder.Transform((ref string input) => input = $"1-{input}");
                }));

            var sanitizer = configuration.CreateSanitizer<TestClass>();
            var result = new TestClass
            {
                PhoneNumber = " 555-555-5555 "
            };
            sanitizer.Sanitize(ref result);

            Assert.AreEqual("1-5555555555", result.PhoneNumber);
        }
    }
}