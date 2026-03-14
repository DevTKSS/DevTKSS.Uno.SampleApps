---
uid: DevTKSS.Uno.Mvux-StateManagement.ListState.UpdateItems.en
---
# How to: Updating ListState Items

## Overview

In this tutorial we extend the previous example by adding the ability to edit items in a `ListState`. You will learn:

- How to create an additional state for user input
- How to use `UpdateAllAsync(...)` to update items
- How to leverage `[FeedParameter]` for cleaner state handling
- Why we need `IListState<T>` instead of `IListFeed<T>` for updates

This scenario demonstrates why we need `ListState` instead of `ListFeed`: while `ListFeed` only supports `RequestRefresh` or `Refresh` actions (requiring a new API/service call), `ListState` allows us to directly update items in the list using filter criteria.

## Prerequisites

Before starting this tutorial, ensure you have:

- Completed [How to: Binding ListState with Selection](xref:DevTKSS.Uno.MvuxStateManagement.ListState.Selection.en) successfully.

## Visual Reference

![Member List Editor with Update Functionality](../../.attachments/Binding-ListState-FeedView.png)

## Extending the Model

We extend our existing Model with an additional state for editing and a method for updating:

### Additional State for Editing

We need a state to hold the modified member name that the user is typing:

```csharp
public IState<string> ModifiedMemberName => State<string>.Empty(this);
```

This state is bound two-way to the `TextBox`, capturing user input.

### Complete Model

Here's what your complete Model looks like:

```csharp
public partial record MainModel
{
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
    
    public IState<string> ModifiedMemberName => State<string>.Empty(this);
}
```

## Extended View (XAML)

Now let's add the editing elements to the UI:

[!code-xaml[](../../../../src/DevTKSS.Uno.MvuxListApp/Presentation/MainPage.xaml#MembersView?highlight=18,23,27,30)]

The new bindings:

- `Text="{Binding Path=ModifiedMemberName, Mode=TwoWay}"` - two-way binding for editing
- `Command="{Binding Path=RenameMemberAsync}"` - triggers the rename operation

## Implementing the Rename Command

> [!NOTE]
> We use a button-triggered command rather than a `.ForEach(...)` callback to give users explicit control over when the rename happens. This prevents unintended changes if the user:
>
> - Selected the wrong member
> - Is still looking up the correct spelling
> - Changes their mind about renaming

Here's the command implementation:

```csharp
public async ValueTask RenameMemberAsync(
    [FeedParameter(nameof(ModifiedMemberName))] string? modName,
    [FeedParameter(nameof(SelectedMember))] string? replaceMember,
    CancellationToken ct)
{
    if (string.IsNullOrWhiteSpace(modName))
        return;

    await Members.UpdateAllAsync(
        match: item => item == replaceMember,
        updater: _ => modName,
        ct: ct
    );

    await Members.TrySelectAsync(modName, ct);
}
```

Key points:

- **`UpdateAllAsync(...)`** - Updates items in the `ListState` matching the filter criteria
- **`match: item => item == replaceMember`** - Finds the currently selected member
- **`updater: _ => modName`** - Replaces it with the new name
- **`TrySelectAsync(...)`** - Re-selects the member by its new name

## Using FeedParameter Attribute

Notice the `[FeedParameter]` attributes on the method parameters. This powerful feature automatically awaits and binds state values to your method parameters, eliminating manual `await` calls:

```csharp
[FeedParameter(nameof(ModifiedMemberName))] string? modName,
[FeedParameter(nameof(SelectedMember))] string? replaceMember
```

> [!TIP]
> **Benefits:**
>
> - No need to manually `await` the states inside the method
> - Parameters can have different names than the original states (improves readability)
> - Cleaner, more focused method implementation

**Alternative:** Use `[ImplicitFeedParameter]` at the class level to automatically bind all parameters by matching names exactly with your states:

```csharp
[ImplicitFeedParameter]
public partial record MainModel
{
    public async ValueTask RenameMemberAsync(
        string? ModifiedMemberName,
        string? SelectedMember,
        CancellationToken ct)
    { ... }
}
```

With `[ImplicitFeedParameter]` on the class, all method parameters are automatically bound by matching their names exactly to your state property names. This means:

- `ModifiedMemberName` parameter automatically binds to the `ModifiedMemberName` state
- `SelectedMember` parameter automatically binds to the `SelectedMember` state
- No need for individual `[FeedParameter]` attributes on each parameter
- Parameter names must match state names exactly (case-sensitive)

## Summary

This example demonstrates:

1. Using two-way binding for user input via `IState<string>`
2. Updating list items with `UpdateAllAsync(...)` - only available on `IListState<T>` (not `IListFeed<T>`)
3. Command-based updates for explicit user control
4. Leveraging `[FeedParameter]` for cleaner async state handling

This pattern ensures data consistency while giving users full control over when changes are committed.
