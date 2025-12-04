---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-DefiningModelOrViewModel.en
---

# How-To: Navigation in the Model or ViewModel

Now let's take a look at how we need to structure our Model or ViewModel to work with Uno Extensions Navigation.

## Prerequisites

1. First of all, create a Model or ViewModel element.

    [!INCLUDE [Guide to creating a basic Model or ViewModel](../HowTo-Adding-New-VM-Class-Record-en.md)]

2. Now add the `INavigator` as a **DependencyInjection** constructor parameter.

    [!INCLUDE [Guide: Use Constructor Parameters for DependencyInjection](../HowTo-Using-DI-in-ctor-en.md)]

## Navigation in Xaml

Basically, you don't actually need navigation code in the ViewModel / Model if you use the `Attached Properties` as described in the [Guide: Defining the UI with NavigationView for ExtensionsNavigation](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.en)!

In this case, it would typically only be the Title properties or others that you bind from View to ViewModel and you would be done. And that is also a big advantage of this extension in my opinion.

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
