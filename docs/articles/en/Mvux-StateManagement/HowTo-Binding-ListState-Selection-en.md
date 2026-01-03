---
uid: DevTKSS.Uno.MvuxStateManagement.ListState.Selection.en
---
# How to: Binding ListState with Selection

## Overview

In this example we show you how to bind a `ListState` from your Model to a `ListView` and how to track the selection of an item. We'll build a simple member list display where users can:

- View a list of members in a `ListView`
- Select a member from the `ListView`
- See the selected member displayed at the top of the page

This example demonstrates the fundamentals of the `.Selection(...)` operator, which works with both `IListState<T>` and `IListFeed<T>`.

## Prerequisites

Before starting this tutorial, ensure you have:

- Completed [How to: Create an Uno Platform App](xref:DevTKSS.Uno.Setup.HowTo-CreateNewUnoApp.en)
- Completed [How to: Adding New Pages](xref:DevTKSS.Uno.Setup.HowTo-AddingNewPages.en)
- Completed [How to: Adding New MVUX Model Classes](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.en)
- Basic understanding of dependency injection from [How to: Using DI in Constructor](xref:DevTKSS.Uno.Setup.Using-DI-in-ctor.en)

## Visual Reference

![Member List UI with Selection](../../.attachments/Binding-ListState-FeedView.png)

## The Model Setup

First, let's define the states needed for display and selection.

### Initializing ListState

There are two common ways to initialize the `ListState<T>`:

#### [Using `ListState.Async(...)`](#tab/Async)

Using the `ListState<string>.Async(...)` method, we can provide an async method that will be called once to get the initial list of Members. This is useful when you need to load data from an API or database asynchronously.

```csharp
private readonly IImmutableList<string> _listMembers = ImmutableList.Create(
    [
        "Hans",
        "Lisa",
        "Anke",
        "Tom"
    ]);

private async ValueTask<IImmutableList<string>> GetMembersAsync(CancellationToken ct)
    => _listMembers;

public IListState<string> Members => ListState<string>.Async(this, GetMembersAsync)
                                                      .Selection(SelectedMember);

public IState<string> SelectedMember => State<string>.Value(this, () => string.Empty);
```

The key elements in this code:

- `_listMembers` - A static immutable list holding our member names
- `GetMembersAsync(...)` - Async method returning the list (even though it's static data)
- `Members` - `IListState<string>` initialized via `Async(...)` with `.Selection(...)` operator
- `SelectedMember` - `IState<string>` that tracks the currently selected member

> [!NOTE]
> While this approach works, it requires significant boilerplate code (property + async method + ListState property) even for static data that doesn't actually need async loading.

#### [Using `ListState.Value(...)`](#tab/Value)

Using the `ListState<string>.Value(...)` method, we can provide a static list of Members directly in a single line. This approach dramatically reduces boilerplate and is perfect for demonstration purposes or when dealing with static data.

```csharp
public IListState<string> Members => ListState<string>.Value(this,
     () => ImmutableList.Create(
        [
            "Hans",
            "Lisa",
            "Anke",
            "Tom"
        ])
    ).Selection(SelectedMember);

public IState<string> SelectedMember => State<string>.Value(this, () => string.Empty);
```

**Advantages over the Async approach:**

- **90% less code** - No separate field or async method needed
- **Multi-line definition** - Clear, readable property expression with proper formatting
- **Immediate clarity** - You can see the data right where it's defined
- **Same functionality** - Still gets the `.Selection(...)` operator and all ListState features
- **Ideal for static data** - No unnecessary async overhead for data that's already available

> [!TIP]
> **When to use Value vs Async:**
>
> - **Use `.Value(...)`** when your data is static, comes from constants, or is computed synchronously
> - **Use `.Async(...)`** when you actually need to fetch data from an API, database, or perform async operations

***

## The View (XAML)

Now that we have our Model set up with the required states, let's create the UI. Our UI consists of a `TextBlock` displaying the selected member and a `ListView` showing all members:

```xaml
<StackPanel Spacing="16">
    <!-- Display selected member -->
    <TextBlock
        Text="{Binding Path=SelectedMember, Mode=OneWay}"
        FontSize="24"
        FontWeight="Bold"/>

    <!-- List of all members -->
    <ListView
        ItemsSource="{Binding Path=Members}"
        SelectionMode="Single"
        Height="300"/>
</StackPanel>
```

> [!WARNING]
> If you use the `ListView`-Control, make sure to **not** set the `ItemClickCommand` property of the `ListView` simultaneously to the `.Selection(...)` operator of the `ListState`, as it will interfere with the selection behavior and not update the State you use to reflect the current selection as expected. You have to choose either one of the two options.

Note the key bindings:

- `ItemsSource="{Binding Path=Members}"` - binds to our `IListState<string>`
- `Text="{Binding Path=SelectedMember, Mode=OneWay}"` - displays the selected member

## Summary

This example demonstrates:

1. Binding `IListState<T>` to a `ListView` with `.Selection(...)` operator (also works with `IListFeed<T>`)
2. Using a separate `IState<string>` to track the selection
3. Displaying the selected item in the UI
4. Two initialization methods: `.Async(...)` for real async data vs `.Value(...)` for static data

In the next tutorial, you'll learn how to edit and update the selected items.
