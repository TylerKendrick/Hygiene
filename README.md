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
