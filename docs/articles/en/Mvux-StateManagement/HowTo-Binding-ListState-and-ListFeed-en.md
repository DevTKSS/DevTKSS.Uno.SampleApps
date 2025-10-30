---
uid: DevTKSS.Uno.Mvux-StateManagement.Overview.en
---
# Overview: Mvux State Management

## Introduction

In this tutorial series you will learn how to use `ListState` and `ListFeed` in your Uno Platform MVUX apps. These components enable you to manage list data reactively with automatic UI updates.

## What's the difference between ListFeed and ListState?

- **`IListFeed<T>`** - Read-only async data collections
  - Ideal for data you only display but don't edit (e.g., server responses)
  - Only supports `RequestRefresh` or `Refresh` (requires new API call)
  - Works with the `.Selection(...)` operator

- **`IListState<T>`** - Read-write data collections
  - Allows direct item updates with `UpdateAllAsync(...)`
  - You can target specific items with filter criteria
  - Also compatible with the `.Selection(...)` operator
  - Ideal for lists where you want to edit, add, or remove items

## Tutorial Series

This series consists of two progressive tutorials:

### 1. [Binding ListState with Selection](xref:DevTKSS.Uno.MvuxStateManagement.ListState-Selection.en)

In this first tutorial you'll learn the basics:

- How to bind a `ListState` to a `ListView`
- How to use the `.Selection(...)` operator
- How to display the selected item in the UI
- Differences between `.Async(...)` and `.Value(...)` initialization

### 2. [Updating ListState Items](xref:DevTKSS.Uno.MvuxStateManagement.Update-ListStateItems.en)

In the second tutorial we extend the functionality:

- How to edit items in a `ListState`
- Using `UpdateAllAsync(...)` with filter criteria
- Leveraging `[FeedParameter]` for cleaner state handling
- Why `IListState<T>` is required for updates

## Prerequisites

Before starting these tutorials, ensure you have:

- Completed [How to: Create an Uno Platform App](xref:DevTKSS.Uno.Setup.HowTo-CreateNewUnoApp.en)
- Completed [How to: Adding New Pages](xref:DevTKSS.Uno.Setup.HowTo-AddingNewPages.en)
- Completed [How to: Adding New MVUX Model Classes](xref:DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.en)
- Basic understanding of dependency injection from [How to: Using DI in Constructor](xref:DevTKSS.Uno.Setup.Using-DI-in-ctor.en)

## Get Started

Begin with the first tutorial: [Binding ListState with Selection](xref:DevTKSS.Uno.MvuxStateManagement.ListState-Selection.en)
