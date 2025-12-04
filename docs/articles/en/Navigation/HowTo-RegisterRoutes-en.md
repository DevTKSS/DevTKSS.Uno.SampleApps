---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.en
---

# How-To: Register and Manage Routes

With `Uno.Extensions.Navigation`, we use a central definition of **route registration** handled in the App class [`App.xaml.cs`(source link)](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/blob/master/src/DevTKSS.Uno.XamlNavigationApp/App.xaml.cs), which can simply be thought of as a map.

## Prerequisites

Before you start with route registration, you need two things:

1. One or more pages (`View`) that you want to use in your app.

   - [Add new page elements to your application](xref:DevTKSS.Uno.Setup.HowTo-AddingNewPages.en)

2. One or more associated `ViewModel` or `Model` that you want to use for the pages. (optional, but recommended)

   - [Add new class or record definitions for a ViewModel or Model](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.en)

## Discovering `RegisterRoutes` Method in `App.xaml.cs`

Add the required method to your App class below the `OnLaunched` method as follows:

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp/App.xaml.cs#L80)]

## Defining the `ViewMap`'s

This tells the Navigator which page (`View`) belongs to which (`View`-)`Model`, where we define properties and functions that the View can call. For this, you will find the `views.Register` section in your application so far, or you can still add it if your application is being upgraded.

```csharp
{
    views.Register(
        new ViewMap(ViewModel: typeof(ShellModel)),
        new ViewMap<MainPage, MainModel>(),
        new DataViewMap<SecondPage, SecondViewModel, Entity>()
```

If additional data objects are required when navigating this route, you convert them as `DataViewMap`, for example, as in the last line.

For example, this is what it looks like in the XamlNavigationApp, where I no longer needed `Entity` and converted this route back accordingly:

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp/App.xaml.cs#L82-L87?highlight=5)]

## Hierarchically Structured `RoutesMap`'s

Now let's look at which routes are accessible from which parent element:

In this example from a Mvux-using application created from the template, you can see from the `Nested:` parameter name, but also from the structure of the section, what such a hierarchy of routes can look like.

```csharp
  routes.Register(
      new RouteMap("", View: views.FindByViewModel<ShellModel>(),
      Nested:
          [
              new RouteMap("Main", View: views.FindByViewModel<MainModel>(), IsDefault:true),
              new RouteMap("Second", View: views.FindByViewModel<SecondModel>())
          ]
      )
  );
}
```

Now, on the `MainPage`, we might want to use a TabBar, NavigationBar, a Frame within a Grid, or even a NavigationView with navigable content property. However, this content might not make sense on the `SecondPage`. In this case, we should ensure that these routes will only be available there.

**We do this, for example, like this:**

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp/App.xaml.cs#L89-L103)]

Here you can see that I added another page, the `DashboardPage`, and created a Model for it named `DashboardModel`. I also nested the `Second` route into the `RouteMap` of the `Main` route.

## Useful Information

When naming, it always makes sense to keep the route and page element names the same. A `DashboardPage` would thus typically receive `Dashboard` as the route name.

If you are using **MVUX** instead of **MVVM**, you should make sure not to mistakenly name the **Model** associated with the page or `View` `DashboardViewModel` for the `DashboardPage`, but `DashboardModel`, because the Mvux source code generator will name the `DashboardViewModel` it creates for you exactly that and otherwise unexpected problems can occur.

## Starting the Application

Now we are done with the route registration and can start the application. If you now start the app, you should be able to see the `MainPage` and navigate from there to the other pages.
