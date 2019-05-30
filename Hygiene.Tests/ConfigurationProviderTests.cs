using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hygiene.Tests
{
    [TestClass]
    public class ConfigurationProviderTests
    {
        [TestMethod]
        public void ComplexPropertyWithInvalidMethodExpression()
        {
            Assert.ThrowsException<InvalidOperationException>(
                () => new SanitizerConfigurationProvider(config =>
                config.ForType<TestClass>(typeBuilder =>
                    typeBuilder.Property(x => x.PhoneNumber.ToLower()))));
        }

        [TestMethod]
        public void ComplexPropertyWithInvalidMethodBodyExpression()
        {
            Assert.ThrowsException<InvalidOperationException>(
                () => new SanitizerConfigurationProvider(config =>
                config.ForType<TestClass>(typeBuilder =>
                    typeBuilder.Property(x => x.ReturnSelf().PhoneNumber))));
        }

        [TestMethod]
        public void ComplexPropertyWithInvalidIdentityExpression()
        {
            Assert.ThrowsException<InvalidOperationException>(
                () => new SanitizerConfigurationProvider(config =>
                config.ForType<TestClass>(typeBuilder =>
                    typeBuilder.Property(x => x))));
        }

        [TestMethod]
        public void ComplexPropertyWithInvalidConstExpression()
        {
            const string value = "some value";

            Assert.ThrowsException<InvalidOperationException>(
                () => new SanitizerConfigurationProvider(config =>
                config.ForType<TestClass>(typeBuilder =>
                    typeBuilder.Property(_ => value))));
        }

        [TestMethod]
        public void ComplexPropertyWithInvalidConstMemberExpression()
        {
            const string value = "some value";

            Assert.ThrowsException<InvalidOperationException>(
                () => new SanitizerConfigurationProvider(config =>
                config.ForType<TestClass>(typeBuilder =>
                    typeBuilder.Property(_ => value.Length))));
        }

        [TestMethod]
        public void ComplexTypeBuilderFailsWithoutSetter()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
                new SanitizerConfigurationProvider(builder
                => builder.ForType<ClassWithoutSetter>(typeBuilder => typeBuilder
                    .Property(y => y.Value)
                    .Transform((ref string input)
                        => input = input.Replace("-", "")))));
        }

        [TestMethod]
        public void ComplexTypeBuilderFailsWithPrivateSetter()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
                new SanitizerConfigurationProvider(builder =>
                builder.ForType<ClassWithoutSetter>(typeBuilder => typeBuilder
                    .Property(y => y.PrivateSetter)
                    .Transform((ref string input)
                        => input = input.Replace("-", "")))));
        }
    }
}