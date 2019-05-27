# Hygiene
A library to formally validate and sanitize assumptions for your code and data.  Hygiene's purpose is to provide common patterns and components for developers to write hygenic, secure, clean code.

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TylerKendrick_Hygiene&metric=alert_status)](https://sonarcloud.io/dashboard?id=TylerKendrick_Hygiene)
[![Build Status](https://dev.azure.com/hygiene/Hygiene/_apis/build/status/TylerKendrick.Hygiene?branchName=dev&jobName=Job)](https://dev.azure.com/hygiene/Hygiene/_build/latest?definitionId=1&branchName=dev)
[![Nuget](https://img.shields.io/nuget/v/hygiene.svg)](https://www.nuget.org/packages/Hygiene/)
[![GitHub](https://img.shields.io/github/license/tylerkendrick/hygiene.svg)](https://github.com/TylerKendrick/Hygiene/blob/dev/LICENSE)

## Purpose
The [CWE/SANS Institute's top 25 most dangerous software errors](https://www.sans.org/top25-software-errors/) lists [improper input validations](http://cwe.mitre.org/top25/archive/2011/2011_mitigations.html#Mit-M1) to be the number one cause of software issues.  In order to avoid these issues, a [Monster Mitigation](http://cwe.mitre.org/top25/index.html#Mitigations) list was created to instruct developers, architects, and engineers in best practices to reduce or eliminate the severity of these issues on software systems.  To assist in these mitigation processes, Hygiene provides an isolated component that can be easily identified to handle input sanitization and validation as a [singular responsibility](https://blog.cleancoder.com/uncle-bob/2014/05/08/SingleReponsibilityPrinciple.html).  By integrating the component into your codebase, you can easily identify where code isn't covered by input sanitization and validation - and decouple this logic from your codebase, keeping your code [clean and cohesive](https://enterprisecraftsmanship.com/2015/09/02/cohesion-coupling-difference/).

## Quickstart
To create an object sanitizer, you need to first configure Hygiene to be aware of the types you are supporting.

```csharp
var configuration = new SanitizerConfigurationProvider(builder => 
{
    //Non-primitive type builders allow for property mutations.
    builder.ForType<Foo>(typeBuilder => typeBuilder
        .Property(instance => instance.Bar)
        .Transform((ref string bar) => bar = bar.Trim()));

    //storing the builder configuration allows you to use it later.
    var stringSanitizer = builder
        // You may also use the type configuration to change the ref instance.
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

```csharp
var phoneNumber = "1- 555-555-5555";
sanitizer.Sanitizer(ref phoneNumber);
```

## Extending the sanitizers
To add new builder operations for your custom types, you can create extension classes to implement your custom behaviors.

```csharp
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

## Resources and Recommended Readings

* [SANS Institute](https://www.sans.org/)
* [Mitre CWE](http://cwe.mitre.org/index.html)
* [SAFE Code](https://safecode.org/)
* [OWASP](https://www.owasp.org/index.php/Main_Page)
