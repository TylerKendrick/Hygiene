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
            var sanitizer = Sanitizer.Create<string>(
                input => input.Trim('-'));
            var result = "--success--";
            await sanitizer.SanitizeAsync(ref result);

            Assert.AreEqual("success", result);
        }

        [TestMethod]
        public async Task ComplexTypeBuilderMeetsExpectations()
        {
            var sanitizer = Sanitizer.Create<TestClass>(
                typeBuilder => typeBuilder
                    .Property(y => y.PhoneNumber)
                    .Transform((ref string input)
                        => input = input.Replace("-", "")));

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
            var sanitizer = Sanitizer.Create<TestClass>(
                typeBuilder =>
                {
                    var propertyBuilder = typeBuilder
                        .Property(x => x.PhoneNumber)
                        .Transform((ref string input)
                            => input = input.Replace("-", "")).Trim();

                    propertyBuilder.Transform(input => $"1-{input}");
                });

            var result = new TestClass
            {
                PhoneNumber = " 555-555-5555 "
            };
            await sanitizer.SanitizeAsync(ref result);

            Assert.AreEqual("1-5555555555", result.PhoneNumber);
        }
    }
}