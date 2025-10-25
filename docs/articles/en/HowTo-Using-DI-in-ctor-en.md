---
uid: DevTKSS.Uno.Setup.Using-DI-in-ctor.en
---
## Guide: Use Constructor Parameters for Dependency Injection

This guide assumes you've already created a Model, ViewModel, or a service class. If not, here's a quick guide to do that: (xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.en)

To use Dependency Injection in your Model, ViewModel, or any class, simply add the required (ideally) interfaces and/or service classes as constructor parameters. The DI container will provide them at runtime.

## [In MVUX](#tab/model-with-di-params)

![Adding-DI-parameters-via-constructor-MVUX](../.attachments/Adding-mvux-model-constructor-DI.png)

## [In MVVM](#tab/viewmodel-with-di-params)

![Adding-DI-parameters-via-constructor-MVVM](../.attachments/Adding-mvvm-viewmodel-constructor-DI.png)

## [Other classes or services](#tab/classes-with-di-params)

![Adding-DI-parameters-via-constructor-Classes](../.attachments/Adding-service-constructor-DI.png)

---
