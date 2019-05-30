using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Hygiene.Tests
{
    [TestClass]
    public class TypeConfigurationAsyncTests
    {
        [TestMethod]
        public async Task SimpleTypeBuilderMeetsExpectations()
        {
            var configuration = new SanitizerConfigurationProvider(builder
                => builder.ForType((ref string input)
                    => input = input.Trim('-')));

            var sanitizer = configuration.CreateSanitizer<string>();
            var result = "--success--";
            await sanitizer.SanitizeAsync(ref result);

            Assert.AreEqual("success", result);
        }

        [TestMethod]
        public async Task ComplexTypeBuilderMeetsExpectations()
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
            await sanitizer.SanitizeAsync(ref result);

            Assert.AreEqual("5555555555", result.PhoneNumber);
        }

        [TestMethod]
        public async Task CompositeBuilderMeetsExpectations()
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
            await sanitizer.SanitizeAsync(ref result);

            Assert.AreEqual("1-5555555555", result.PhoneNumber);
        }
    }
}