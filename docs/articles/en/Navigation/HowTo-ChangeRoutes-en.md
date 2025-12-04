---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-ChangeRoutes.en
---

# How-To: React to Route Changes

If we now have routes registered in our application, we may also want to react to changes in the route, for example to execute certain actions or load data.

For this, we can use the `IRouteNotifier` to inform us about changes to the current route. It contains the `RouteChanged` event, which is triggered when the route changes. In the following example, I will show you how to implement this in your application.

## Prerequisites

Before you start with the implementation, you need the Uno feature "Navigation" in your application, i.e. the `Uno.Extensions.Navigation` library, but also have one or more [routes registered](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.en) and have created a ViewModel or Model class with an associated page, i.e. View, and be able to navigate there. For simplicity, I will assume that you have already successfully completed the following three tutorials:

- [Tutorial: Creating the UI with a `NavigationView` in Xaml](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.en)
- [Tutorial: Registering Routes in the App](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.en)
- [Tutorial: Navigation in the Model or ViewModel](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel.en)

## Tutorial Video: Reacting to Route Changes

In this video, we will look at how you can react to route changes in your application by using the `IRouteNotifier`. We will see how to subscribe to the `RouteChanged` event and respond to it. You can copy the code directly from the code below and paste it into your application if you want, but from my own experience, it helps you more to write the code yourself and watch how it works. This way you can also better understand what you are doing and why.

> [!NOTE]
> This video is currently only available in German, but transcriptions have been added to the video description, which should be usable through YouTube's auto-translate feature. You can also enable auto-translated subtitles in YouTube to follow along in your preferred language.

![Responding-to-Route-Changes-with-IRouteNotifier](https://www.youtube.com/embed/RZ3RirA7jhk)

## Requesting IRouteNotifier in the Model Constructor

To use the `IRouteNotifier` in your Model or ViewModel, you need to request it as a dependency in the constructor. Here is an example of how you can do this in a ViewModel:

```csharp
public partial record MainModel
{
    private readonly IRouteNotifier _routeNotifier;

    public MainModel(IRouteNotifier routeNotifier)
    {
        _routeNotifier = routeNotifier;
        _routeNotifier.RouteChanged += OnRouteChanged;
    }

    private void OnRouteChanged(object sender, RouteChangedEventArgs e)
    {
        // Here you can later react to the route change
    }
}
```

> [!IMPORTANT]
> In my experience, the most reliable approach is to extract the event into a separate method, rather than registering it as a lambda expression in the constructor. Although the same thing should happen, I often had the problem that the method was not called when I wrote it as a lambda expression.

## Linking the Route Name with an `IState<string>` in the Model

To store and access the current route name in your Model or ViewModel, you can use an `IState<string>`. Here is an example of how you can implement this:

```csharp
public IState<string> Title => State<string>.Value(() => "Dashboard");
```

Now the current content is hardcoded, of course. But what if we change our mind in the meantime and rename the page? And do we even want the title, in this case our current route name, to depend on what our Model is called? Let's assume that this is not the case.

1. So, if we want to use the current route name as the initial value without hardcoding the name, we first need an `INavigator`, if we haven't requested it before:

    ```diff
    public partial record MainModel
    {
        private readonly IRouteNotifier _routeNotifier;
    +   private readonly INavigator _navigator;

        public MainModel(
            IRouteNotifier routeNotifier,
    +       INavigator navigator)
        {
            _routeNotifier = routeNotifier;
            _routeNotifier.RouteChanged += Main_OnRouteChanged;
    +       _navigator = navigator;
        }
    }
    ```

2. And then we can directly query our current route on which we are located:

    ```csharp
    public IState<string> Title => State<string>.Value(this, () => _navigator.Route?.ToString() ?? string.Empty);
    ```

    **What happens here?**
    What we have effectively changed now is that we now:
    1. Query the `Route` property from our Navigator, which returns the current `Route` object or (according to the compiler) possibly also `null`.
    2. The `Route` type has an override of the `ToString()` method, which returns the route name as a `string` when queried.
    3. If this value itself or as a result of a `null` value of the `Route` property should be `null`, we return an empty string instead using the null-coalescing operator `??`.

And so we already have our current route name readily stored in our Model in the `Title`.

But of course, this doesn't help our user in the Model itself, so we still have to display it somehow in the UI. Do you remember that I showed you in the [Tutorial: Creating the UI with a `NavigationView` in Xaml](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.en) how to bind the header of the `NavigationView` to a property in the Model? Coincidentally, this property was called exactly `Title`. Perfect!

If you haven't done this yet, it's very easy to do it afterwards:

```diff
<NavigationView uen:Region.Attached="True"
+               Header="{Binding Title}"
                IsPaneToggleButtonVisible="True"
                PaneDisplayMode="Auto">
<NavigationView.MenuItems>
    <NavigationViewItem Content="Home"
                        uen:Region.Name="Dashboard"
                        Icon="Home" />
    <NavigationViewItem Content="Some View"
                        uen:Region.Name="Second"
                        Icon="AddFriend" />
</NavigationView.MenuItems>
        <NavigationView.Content>
            <Grid uen:Region.Attached="True" />
        </NavigationView.Content>
</NavigationView>
```

## Reacting to Route Changes

Now we only need the actual reaction to the route change. We do this in the `OnRouteChanged` method, which we registered in the constructor earlier. Here is an example of how you can implement this:

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp/Presentation/MainModel.cs#L19-L22)]

**What happens here?**

1. An `IState<T>` has the `SetAsync` method, with which we can change the value of the state. This is asynchronous, so we use the `await` keyword before it.
2. In the RouteChangedEventArgs `e` we get the `Navigator`, which, as before when [linking the route name](#linking-the-route-name-with-an-istatestring-in-the-model), returns the current route name as a `string` in the overload of the `Route.ToString()` method.
3. We then pass this directly to the `SetAsync` method and let Mvux handle the update of the state and thus also the UI for us.

> [!TIP]
> Did you notice that we had to use `async void` here for the EventHandler `OnRouteChanged`? This is because EventHandlers must always return `void`. In such cases, it is common to use `async void` to perform asynchronous operations. However, you should only use `async void` in such cases with EventHandlers and otherwise always prefer `async Task` or `ValueTask` for better error handling and control over asynchronous operations. Without the `async` keyword, we couldn't use `await`, which is absolutely necessary here to call the asynchronous method `SetAsync` without getting a message from the compiler that we should use `await`.

## Starting the Application

Now we are done creating our code and can simply start the application.

If you now click on another menu item in the NavigationView and have correctly registered the routes beforehand, you should see that the text in the header of the NavigationView changes accordingly and displays the current route name.

Congratulations! You have successfully learned how to respond to route changes in your application by using the `IRouteNotifier` and storing the current route name in your Model.

**Here is the complete code you should have in your Model from this tutorial:**

[!code-csharp[](../../../../src/DevTKSS.Uno.XamlNavigationApp/Presentation/MainModel.cs#L3-L25)]

## Links to Uno Documentation

- [IRouteNotifier Documentation](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/Advanced/HowTo-IRouteNotifier.html)
