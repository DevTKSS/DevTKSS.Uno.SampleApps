---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel.en
---

# How-To: Navigation in the Model or ViewModel

Now let's take a look at how we need to structure the connection between the `View` and the `ViewModel` to work with Uno Extensions Navigation.

First, let's ask ourselves the question: **Navigation only in Xaml - Is that even possible?**

*Yes and No.*

So, let's take a closer look. What does this mean?

- **Yes:**

  In fact, you basically don't need either codebehind or code in the ViewModel / Model for navigation if you use the `Attached Properties` in the Xaml of your page.

  **If you're interested in how this works, you can find it directly here:**

  [How-To: Defining the UI with NavigationView for ExtensionsNavigation](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.en)

  In this case, it would typically only be the properties to display, like the `string` property `Title`, that you bind from your `Page`, i.e., your `View` to the `ViewModel` or `Model`, and you're done!

  > [!TIP]
  > By the way, with the `Attached Properties` `uen:Navigation.Request` and `uen:Navigation.Data` you can also pass data to navigation, as [explained well in the Uno documentation using `Widget` elements as examples](https://platform.uno/docs/articles/external/uno.extensions/doc/Learn/Navigation/HowTo-NavigateInXAML.html#2-navigationdata). However, for this you'll need `DataViewMap` definitions in the route registration.

- **No:**

  1. You still need to register the routes you want to navigate in the `RegisterRoutes` method in the `App.xaml.cs` class, so the `INavigator` knows what belongs together and from where you want to allow navigation to which routes with which "qualifiers".
  2. If you want to trigger navigation in your Model or ViewModel, then of course you need the `INavigator` there to start the navigation.

## Creating the Prerequisites

Okay, so let's assume we have the second case mentioned above and want to do the following:

1. Our user should be able to trigger a function in our `ViewModel` or `Model` by clicking a `Button`
2. This function should navigate them to the `SecondPage` that we included in the Uno App template, but it could also be any other page you created and registered yourself.

    Let's assume this is our `App.xaml.cs` with the `RegisterRoutes` method:

    ```csharp
    {
        views.Register(
            new ViewMap(ViewModel: typeof(ShellModel)),
            new ViewMap<MainPage, MainModel>(),
            new DataViewMap<SecondPage, SecondViewModel, Entity>()
        );

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

But how should our `ViewModel` or `Model` look so we can implement this?

For this we need the following steps:

## Prerequisites

1. [Create a Model or ViewModel](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.en)

2. [And get the `INavigator` there as a **`DependencyInjection` Constructor Parameter**](xref:DevTKSS.Uno.Setup.Using-DI-in-ctor.en)

## Binding View UI Controls to Properties in the ViewModel or Model

Now we have previously set the `Title` of the NavigationView manually, but what about other properties that we want to bind in the View? And you may have also seen the `Name` defined in the `Dashboard(View)Model` in the template app.

If you're not starting from the template, add this property to bind it in the View.

```csharp
public string? Name { get; set; }
```

### [Mvvm](#tab/mvvm)

```csharp
public partial class DashboardViewModel : ObservableObject
{
    private readonly INavigator _navigator;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(NavigateSecondAsyncCommand))]
    private string? name;

    public DashboardViewModel(INavigator navigator)
    {
        _navigator = navigator;
        NavigateSecondAsyncCommand = new AsyncRelayCommand(NavigateSecondAsync);
    }

    public IAsyncRelayCommand NavigateSecondAsyncCommand { get; }

    [RelayCommand(CanExecute = nameof(CanExecuteNavigateSecondAsync))]
    private async Task NavigateSecondAsync()
    {
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
    }

    private bool CanExecuteNavigateSecondAsync()
    {
        return !string.IsNullOrWhiteSpace(Name);
    }
}
```

With this code, you can bind the `Name` property in the View and use the `NavigateSecondAsyncCommand` to navigate to the `SecondViewModel`.

You can use a button or another control in the View to trigger navigation, but by binding the `IsEnabled` property of the control to the `CanExecute` status of the command, you can only execute navigation when the name is not empty.

### [Mvux](#tab/mvux)

```csharp
namespace Mvux.XamlNavigationApp.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public DashboardModel(INavigator navigator)
    {
        _navigator = navigator;
        Title = "Dashboard";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task NavigateSecondAsync()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

}
```

Here you can define a button in the View that calls the `NavigateSecondAsync` method to navigate to the `SecondModel`, retrieve the `Name` value, and pass it as data to the next page.

If you compare how this looks in MVVM and MVUX, you'll notice it's fundamentally quite similar, but in MVUX the whole thing is somehow more organized and you need less "boilerplate" code to achieve the same result.

To create a TwoWay binding directly on the `IState<string> Name` in the View, you don't even need a `PropertyChanged` notification like you would in MVVM. Instead, you simply attach a `.ForEach(...)` to the `.Value(...)`, create a method that receives the new value, and you can work with it directly. No more tedious implementation of `INotifyPropertyChanged`.

Learn more about this in the [Guide: React to Route Changes](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-ChangeRoutes.en).

---
