# Hygiene
Provides input sanitizers for developers to write hygenic, secure, clean code.

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TylerKendrick_Hygiene&metric=alert_status)](https://sonarcloud.io/dashboard?id=TylerKendrick_Hygiene)
[![Build Status](https://dev.azure.com/hygiene/Hygiene/_apis/build/status/TylerKendrick.Hygiene?branchName=dev&jobName=Job)](https://dev.azure.com/hygiene/Hygiene/_build/latest?definitionId=1&branchName=dev)
[![Nuget](https://img.shields.io/nuget/v/hygiene.svg)](https://www.nuget.org/packages/Hygiene/)
[![GitHub](https://img.shields.io/github/license/tylerkendrick/hygiene.svg)](https://github.com/TylerKendrick/Hygiene/blob/dev/LICENSE)
![Net Standard](https://img.shields.io/badge/net%20standard-%3E%3Dv2.0-blue.svg)

## Purpose
Hygiene sanitizers allow for configurable components to handle your sanitization logic.
```csharp
//Creates a sanitizer.
var sanitizer = Sanitizer.Create<string>(
    input => input.Replace("not", "").Trim());

var valueToSanitize = "not correct";
//Executes the sanitization logic.
sanitizer.Sanitize(ref valueToSanitize);

Console.WriteLine(valueToSanitize); //Outputs "correct".
```
By integrating the sanitizers into your codebase, you can easily identify where code isn't covered by sanitization and decouple this logic from your codebase, keeping your code [clean and cohesive](https://enterprisecraftsmanship.com/2015/09/02/cohesion-coupling-difference/).
  
The [CWE/SANS Institute's top 25 most dangerous software errors](https://www.sans.org/top25-software-errors/) lists [improper input validations](http://cwe.mitre.org/top25/archive/2011/2011_mitigations.html#Mit-M1) to be the number one cause of software issues.  In order to avoid these issues, a [Monster Mitigation](http://cwe.mitre.org/top25/index.html#Mitigations) list was created to instruct developers, architects, and engineers in best practices to reduce or eliminate the severity of these issues on software systems.  To assist in these mitigation processes, Hygiene provides an isolated component that can be easily identified to handle input sanitization and validation as a [singular responsibility](https://blog.cleancoder.com/uncle-bob/2014/05/08/SingleReponsibilityPrinciple.html).

## Quickstart
To create an object sanitizer, you need to first configure Hygiene to be aware of the types you are supporting.

```csharp
var configuration = new SanitizerConfigurationProvider(builder => 
{
    //storing the builder configuration allows you to use it later.
    var localSanitizer = builder
        // You may also use the type configuration to change the ref instance.
        .ForType<string>((ref string value) =>
        {
            //Using the pass-by-ref transformer allows conditional assignment.
            if(value != null) value = value.Trim();
        });
    
    //Typed builders can be converted into Visitor delegate instances.
    builder.ForType<Bar>(typeBuilder => typeBuilder
        .Property(instance => instance.FooBar)
        //Using the sanitizer overload for transform allows reuse of sanitizers.
        .Transform(localSanitizer));
        
    //Non-primitive type builders allow for property mutations.
    builder.ForType<Foo>(typeBuilder => typeBuilder
        .Property(instance => instance.Bar)
        //Using the mutator overload for transform uses implicit reassignment.
        .Transform(bar => bar.Trim()));
});

// use DI or create the sanitizer yourself
var fooSanitizer = configuration.CreateSanitizer<Foo>();
var barSanitizer = configuration.CreateSanitizer<Bar>();
var stringSanitizer = configuration.CreateSanitizer<string>();
```

Alternatively, you can create an instance for one-off types without a configuration provider with a static factory method.

```csharp
var sanitizer = Sanitzer.Create<string>(instance => instance.Replace(' ', ''));
```

To use a sanitizer, simply pass the object by reference and invoke the sanitizer.

```csharp
var phoneNumber = "1- 555-555-5555";
stringSanitizer.Sanitize(ref phoneNumber);
```

## Extending the sanitizers
To add new builder operations for your custom types, you can create extension classes to implement your custom behaviors.
```csharp
public static class CustomExtensions
{
    //Demonstrates an extension for a non-primitive type.
    public static ISanitizerTypeBuilder<Foo> CustomLogic(
        this ISanitizerTypeBuilder<Foo> self,
        //Define custom parameters here.
        Bar extensionParameter) => self
        .Transform((ref instance) =>
            //Implement custom sanitization logic
            instance.Bar = extensionParameter.Normalize());
}

//Use the extension when configuring your sanitizers.
var foo = new Foo();
var bar = new Bar();
var sanitizer = Sanitizer.Create<Foo>(
    //Can now call the extension during configuration.
    x => x.CustomLogic(bar));

sanitizer.Sanitize(ref foo);
//foo.Bar == bar
```

Another more practical example would be for encryption.
```csharp
public static class SanitizerBuilderExtensions
{
    public static ISanitizerTypeBuilder<string> Encrypt(
        this ISanitizerTypeBuilder<string> self,
        RijndaelManaged algorithm) => self
        .Transform(instance =>
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
                    streamWriter.Write(instance);
                // This implicitly sets the referenced variable.
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        });
}
```

## Where to get it
Install from nuget
```
> dotnet add package Hygiene --version 1.0.0
```
Or [download](https://github.com/TylerKendrick/Hygiene/releases/tag/v1.0.0) from the release page.

## API Design Inspirations

* [Fluent Validation](https://github.com/JeremySkinner/FluentValidation)
* [Entity Framework Core](https://github.com/aspnet/EntityFrameworkCore)
* [Automapper](https://github.com/AutoMapper/AutoMapper)

## Resources and Recommended Readings

* [SANS Institute](https://www.sans.org/)
* [Mitre CWE](http://cwe.mitre.org/index.html)
* [SAFE Code](https://safecode.org/)
* [OWASP](https://www.owasp.org/index.php/Main_Page)
