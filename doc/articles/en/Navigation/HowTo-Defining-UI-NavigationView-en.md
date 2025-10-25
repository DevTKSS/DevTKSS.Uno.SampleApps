---
uid: DevTKSS.Uno.ExtensionsNavigation.HowTo-Defining-UI.en
---

# How To: Create the UI with a `NavigationView` in XAML

In this part of the tutorial, we will look at how to create simple page navigation using a `NavigationView`.

**Previously in this tutorial...**

We have previously looked at what we can do with `Uno.Extensions.Navigation` and the `NavigationView` in the intro, and then adjusted the setup of the application or created it. Now we want to see how to actually implement it!

## Tutorial Video: Navigation with `NavigationView` in MVUX and XAML

In this video, we will look together at how to set up and use a `NavigationView` control in a XAML Markup App. We will implement navigation between different pages while applying MVUX principles. You can copy the code directly from the code below and paste it into your application if you want, but from personal experience, it helps you more to write the code yourself and watch how it works. This way you can also better understand what you are doing and why.

> [!NOTE]
> This video is currently only available in German, but transcriptions have been added to the video description, which should be usable through YouTube's auto-translate feature. You can also enable auto-translated subtitles in YouTube to follow along in your preferred language.

![Navigation-in-Xaml-und-Mvux-mit-Navigation-View](https://youtube.com/embed/knt2oOjHH30)

## Implementing the NavigationView

We will first add a simple `NavigationView` to the `MainPage` of the application. There should already be a `Grid` with a `StackPanel` if you created an application from the template.

From this starting point, first remove the `StackPanel` including the controls it contains and add this simple definition of the `NavigationView` instead:

```xml
<Grid utu:SafeArea.Insets="VisibleBounds">
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <NavigationView Header="{Binding Title}"
                    IsPaneToggleButtonVisible="True"
                    PaneDisplayMode="Auto">
        <NavigationView.MenuItems>
            <NavigationViewItem Content="Home"
                                Icon="Home" />
            <NavigationViewItem Content="Some View"
                                Icon="AddFriend" />
        </NavigationView.MenuItems>
        <NavigationView.Content>
            <Grid />
        </NavigationView.Content>
    </NavigationView>
</Grid>
```

> [!NOTE]
> If your application does not include the Uno Toolkit feature, you can simply remove or omit `utu:SafeArea.Insets="VisibleBounds">` in the first line.

## Namespaces and Extended Properties

Now we want to add the properties enabled by the extension, so-called `Attached Properties`.

1. To do this, first add `xmlns:uen="using:Uno.Extensions.Navigation.UI` to the collection at the top of your page.
2. Then add the property `uen:Region.Attached="True"` to the properties of the `Grid`, as well as to those of the `NavigationView` itself, but also in the `Grid` in the `Content` area of the `NavigationView`. With this, we tell the navigator that a navigation route or nested navigation display is expected and should be used within this control.

    This should then look like this:

    ```diff
    +<Grid uen:Region.Attached="True"
        utu:SafeArea.Insets="VisibleBounds">
        <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
    + <NavigationView uen:Region.Attached="True"
                    Header="{Binding Title}" <-- Optional binding to the Title property in the ViewModel
                    IsPaneToggleButtonVisible="True"
                    PaneDisplayMode="Auto">
    <NavigationView.MenuItems>
        <NavigationViewItem Content="Home"
                            Icon="Home" />
        <NavigationViewItem Content="Some View"
                            Icon="AddFriend" />
    </NavigationView.MenuItems>
        <NavigationView.Content>
    +     <Grid uen:Region.Attached="True" />
        </NavigationView.Content>
    </NavigationView>
    </Grid>
    ```

3. Now we add a few route identifier names using `uen:Region.Name="..."`.

    ```diff
    <Grid uen:Region.Attached="True"
        utu:SafeArea.Insets="VisibleBounds">
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto"/>
    </Grid.RowDefinitions>
    <NavigationView uen:Region.Attached="True"
                    Header="{Binding Title}"
                    IsPaneToggleButtonVisible="True"
                    PaneDisplayMode="Auto">
    <NavigationView.MenuItems>
        <NavigationViewItem Content="Home"
    +                       uen:Region.Name="Dashboard"
                            Icon="Home" />
        <NavigationViewItem Content="Some View"
    +                       uen:Region.Name="Second"
                            Icon="AddFriend" />
    </NavigationView.MenuItems>
            <NavigationView.Content>
                <Grid uen:Region.Attached="True" />
            </NavigationView.Content>
        </NavigationView>
    ```

4. Finally, the `Grid` that we want to use for the navigation of the `NavigationView` content now needs two more very important properties set, without which it is quite possible that our plan will fail.

   We need to:

   1. Append `uen:Region.Navigator="Visibility"`
   2. Set the `Visibility` property to visible

   And this is how:

    ```diff
    <NavigationView.Content>
    <Grid uen:Region.Attached="True"
    +      uen:Region.Navigator="Visibility"
            Visibility="Visible" />
    </NavigationView.Content>
    ```

   **As a brief explanation of the properties added there:**

   - **The `Visibility` property:**

     By setting this, we ensure that the content of this route is initially visible.

   - **The Navigator identifier name:**

     With this, we tell the functions provided by the extension that we want to make the elements marked with this visible and invisible when we call the associated navigation route.

     *The naming is by no means a coincidence!*

     >[!NOTE]
     > The "Visibility" navigator is the available identifier for this property according to the documentation.

## Next Steps

Now we have set up the `NavigationView` and can use it to navigate between pages. In the next step, we will look at how we can define routes and implement navigation between pages.

[**Define Routes and Implement Navigation**](xref:DevTKSS.Uno.ExtensionsNavigation.HowTo-RegisterRoutes.en)
