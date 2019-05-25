# Hygiene
A library to formally validate and sanitize assumptions for your code and data.  Hygiene's purpose is to provide common patterns and components for developers to write hygenic, secure, clean code.

[![Build Status](https://dev.azure.com/hygiene/Hygiene/_apis/build/status/TylerKendrick.Hygiene?branchName=dev&jobName=Job)](https://dev.azure.com/hygiene/Hygiene/_build/latest?definitionId=1&branchName=dev)
[![Nuget](https://img.shields.io/nuget/v/hygiene.svg)](https://www.nuget.org/packages/Hygiene/)
![GitHub](https://img.shields.io/github/license/tylerkendrick/hygiene.svg)

## Quickstart
To create an object sanitizer, you need to first configure Hygiene to be aware of the types you are supporting.

```
var configuration = new SanitizerConfigurationProvider(builder => 
{
    //Non-primitive type builders allow for property mutations.
    builder.ForType<Foo>(typeBuilder => typeBuilder
        .Property(instance => instance.Bar)
        .Transform((ref string bar) => bar = bar.Trim()));

    //storing the builder configuration allows you to use it later.
    var stringSanitizer = builder
        // You may also use the type configuration to change the ref instanc.e
        .ForType<string>((ref string value) =>
            value = value.Trim());
    
    builder.ForType<Bar>(typeBuilder => typeBuilder
        .Property(instance => instance.FooBar)
        .Transform(stringSanitizer));
});

// use DI or create the sanitizer yourself
var fooSanitizer = configuration.CreateSanitizer<Foo>();
var barSanitizer = configuration.CreateSanitizer<Bar>();
var stringSanitizer = configuration.CreateSanitizer<string>();
```

To use a sanitizer, simply pass the object by reference and invoke the sanitizer.

```
var phoneNumber = "1- 555-555-5555";
sanitizer.Sanitizer(ref phoneNumber);
```

## Extending the sanitizers
To add new builder operations for your custom types, you can create extension classes to implement your custom behaviors.

```
public static class SanitizerBuilderExtensions
{
    public static ISanitizerTypeBuilder<Foo> Encrypt(
        this ISanitizerTypeBuilder<Foo> self,
        RijndaelManaged algorithm) => self
        .Property(instance => instance.Bar)
        .Transform((ref string instance) =>
        {
            var iv = algorithm.IV;
            var length = iv.Length;
            var encryptor = algorithm.CreateEncryptor(algorithm.Key, iv);
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(BitConverter.GetBytes(length), 0, sizeof(int));
                memoryStream.Write(iv, 0, length);
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                using (var streamWriter = new StreamWriter(cryptoStream))
                    streamWriter.Write(instance.Bar);
                instance.Bar = Convert.ToBase64String(memoryStream.ToArray());
            }
        });
}
```
