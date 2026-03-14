# Uno Platform MVUX Sample Apps - AI Coding Guide

## Project Context

This is a (primary) **German-localized** learning repository for **Uno Platform 6.3.28+** showcasing MVUX (Model-View-Update-eXtended) patterns, navigation, and Uno.Extensions. All apps use `.NET 9.0` with the `Uno.Sdk` (see `src/global.json`). Project context defaults to **Uno Platform, not MAUI**.

### Project Structure

**Default structure:** Place all Views and Models in the `/Presentation` folder. Only if the app grows larger, add further subfolders (as seen in MvuxGallery) within `/Presentation` to keep the structure organized and concise.

```
src/
├── DevTKSS.Uno.Samples.MvuxGallery/     # Main gallery app
│   ├── Presentation/
│   │   ├── ViewModels/*Model.cs         # MVUX partial records
│   │   ├── Views/*Page.xaml             # Pages (not Views/)
│   │   ├── Shell.xaml                   # Main navigation shell
│   ├── Models/                          # Domain models & services
│   ├── appsettings.json                 # Config sections (AppConfig, Localization)
│   ├── appsettings.sampledata.json      # Sample data for code examples
├── DevTKSS.Extensions.Uno.Storage/      # Custom storage extensions
├── global.json                          # Uno.Sdk version (6.3.28)
├── Directory.Packages.props             # Central package management
```

### UnoFeatures in .csproj
Apps declare capabilities via `<UnoFeatures>`:
- Material: Theming, Relyable for `ColorPaletteOverride`
- MVUX
- MVVM (prefer not using this at the same time as MVUX)
- Navigation
- Hosting (Hosting + DI)
- Configuration - App settings with `IOptions<T>` and Configuration binding, is supporting `IOptionsMonitor<T>` but using `IConfigBuilder.Section<T>()` does set `reloadOnChange: false`! Do not manually change, the user will do if needed!
- Localization
- Serialization
- Storage
- Toolkit - provides powerful controls and binding helpers e.g.:
  - `AncestorBinding`: to access parent DataContexts or other elements in the visual tree.
  - `ItemsControlBinding`: advanced binding scenarios for ItemsControls.
  - `CommandExtensions`: enhanced command binding capabilities, especially useful for MVUX. Allowes binding Commands to async Task/ValueTask methods in the Model on controls which do not support Command binding out of the box.
- ThemeService
- SkiaRenderer - Performanct graphic rendering. **ONLY** non-supported platform is Windows! This will **always** use Native Rendering!

## Strict Constraints you MUST comply with
The following are ABSOLUTE RULES you MUST always follow when editing code in this repository, except from explicitly requested otherwise!

- **Do not manually add implicit package references** - they're managed by Uno.Sdk.
- We are using Global Usings via `GlobalUsings.cs` in each project. If you need additional usings, add them there and not in individual files.
- Using MVUX Architecture (the `csproj` will contain `<UnoFeatures>MVUX</UnoFeatures>`) Always lookup the section in this Instructions!
- Using Uno Extensions Navigation (the `csproj` will contain `<UnoFeatures>Navigation</UnoFeatures>`):
  - Ensure all Views and Models are properly registered in `App.xaml.cs`

**Facts and Strict Constraints in Context of `this.InitializeComponent()`:**
- You MUST NOT remove this from anywhere you find this line! Removing it will break the app and prevent any XAML from loading.
- No matter what errors or warnings you see, this line is always *required to successfully initialize* the XAML components of the View/Page/App and in absolutely **NO** Situation the issue source!
- NEVER even consider deleting or comment out this line!
- Never Remove or Replace any lines with Placeholders, comments (e.g. `// ...existing code...`) or Sample content!
- Especially the `net*.0-windows*` TargetFramework is known to trigger false warnings/errors about this line would be unknown or missing using directives. In case of the Project is brand new, this will potentially be present in 99% of the cases and you MUST ignore those warnings/errors!
- Even if you just remove the "unnesseary" `this.` prefix, this is NOT wanted!
- You MUST always keep this line as-is!

What you will check and fix instead:
- There are no typos or mismatches in file/class names or XAML root element names.
- The `*Page.xaml.cs` (Codebehind) class:
  - Has the correct `partial` modifier
  - Matches the `x:Class` attribute in the corresponding `*Page.xaml` root element
  - The constructor calls `this.InitializeComponent();` before you may access any fields or properties from the to-be-connected xaml! Even prefer having this the first call in the constructor body!
  - If using MVUX:
    - The Page **MUST NOT** have *any* direct references (e.g. fields, properties, events... whatever!) to the Model in codebehind!
    - Always use `{Binding}` to the MVUX-generated ViewModel *in XAML* instead. Properties are equally named as in the Model's stateful properties. Commands bind to async Task/ValueTask method names.
    - Except from special User Interaction (Keyboard events, but NOT simple Click/Tap events), codebehind is rarely needed! MVUX is designed to avoid codebehind usage via powerful binding and command patterns.
    - In 90% of cases, achieve what you want via XAML Bindings only. Use Uno.Toolkit controls and binding helpers.
    - **Before** accessing `DataContext` in codebehind: Ask the Developer (via VS Copilot Chat) for agreement and provide a reasoned explanation.

## MVUX Architecture

**Known false warnings/errors you MUST ignore:**

Generated ViewModels and analyzer notes:
- During test builds or when stepping through in the debugger, you may see messages about a missing `BindableAttribute` on models; these are expected with MVUX source generation and can be ignored.
- Do not add attributes or change patterns to “fix” these messages; the source generator handles the bindable surface. Never modify generated code under `obj/`.

**Conventions and Patterns:**

- **All "Model"'s are defined as `partial record` types** named `*Model` (e.g., `DashboardModel`, `MainModel`).
- Models are not the ViewModels themselves per definition. The bindable **ViewModel is auto-generated** from each `*Model` by the MVUX source generators at compile time.
- The User you speak to in chat or documentation may refer to "ViewModel". This is impling the Model when working with MVUX, NOT the actual Source Generated ViewModel! You may only edit `*Model` code.
- You should never edit or depend on the generated files directly.
- Models use constructor injection for services (DI via Uno.Extensions.DependencyInjection -> `<UnoFeatures>Hosting</UnoFeatures>`). Pages NOT!
- Models define **stateful properties** using `IState<T>`, `IListState<T>`, `IFeed<T>`, and `IListFeed<T>` from `Uno.Extensions.Reactive`.

**Strict Constraints you MUST ALWAYS adhere to:**
- **Fields and Properties in Models:**
  - Models might have fields for injected services, `IOptions<T>` provided Configuration *objects* (**DO NOT** set the field as `IOptions<T>` if it is not a `IOptionsMonitor<T>`) and Properties that are not expected to be updated/reactive.
  - Properties that the UI binds to and are expected to be changing are exposed as `IFeed<T>`, `IListFeed<T>`, `IState<T>`, or `IListState<T>`.
  - You **MUST NOT** use `INotifyPropertyChanged` or Events for those Statefull properties! -> MVUX generates reactive bindings automatically.
  - Instead of using Events or `INotifyPropertyChanged` triggered by a Property Change in a MVVM app, you will migrate them to `IState<T>` or `IListState<T>`.
  - If the Property is expected to be fed from external data sources / services, but your code is not expected or allowed to change the data, you will use `IFeed<T>` or `IListFeed<T>`.
  - The `<T>` generic type parameter of a Statefull Property like those representing the data type (e.g., `string`, `int`, `MyCustomType`, etc.) is **NEVER** nullable!
    - This is **WRONG!!!:** `IState<string?>`, `IListState<MyCustomType?>`
    - If you would expect the value eventually beeing null, or see compiler `possible null reference` warnings, use the `Option<T>` pattern instead (e.g., `Option<MyCustomType>.Some(value)` / `Option<MyCustomType>.SomeOrDefault(value)`).
    - If you connect Callback Handlers of e.g. `IState<T>` or `IListState<T>` via the MVUX **`ForEach` operator**, you may still recieve `null` value in the Handling Method, so before you use `Update*`-Methods on those Statefull properties, always check for `null` and rather not update then update with null values!
- **UI Layer Constraints:**
  - Where the UI needs to bind to these use `{Binding}` in XAML.
  - If your bound UI control has an `ItemsSource` (e.g. `ListView` or `ItemsRepeater`), you **MUST** use `IListFeed<T>` or `IListState<T>`, **NOT** `ObservableCollection<T>` or `List<T>`!
  - For Selection support, see the "Selection with IListState/IListFeed" section below in Feed vs State.

#### Feed vs State
- **Feeds (`IFeed<T>`, `IListFeed<T>`)**: Read-only async data streams from services
  - Stateless, reactive sequences similar to `IObservable<T>`
  - Use for data you won't edit (e.g., server responses)
  - Initialize:
    - Async: `IListFeed<Person> People => ListFeed.Async(_service.GetPeopleAsync);`
    - Async Enumerable: `IListFeed<Person> People => ListFeed.AsyncEnumerable(_service.GetPeopleAsyncEnumerable);` - make sure the Service Method uses `[AsyncEnumerableCancellationToken]CancellationToken`!
    - Value: **NOT SUPPORTED** - Feeds are always async!
    - Empty list: `IListFeed<Item> Items => ListFeed<T>.Empty(this);`
      - **IMPORTANT:** The `.Empty()` initializer is only available at `ListFeed<T>.Empty(this)` but is not at a non-typed `ListFeed.Empty(...)`!
  - Request refresh with:
    - `public IListFeed<Person> People => ListFeed.Async(_service.GetPeopleAsync);` -> call `await People.TryRefreshAsync(cancellationToken);` to request a refresh
    - `public IFeed<string> Title => Feed.Async(async () => "Hello MVUX");` -> call `await Title.TryRefreshAsync(cancellationToken);` to request a refresh
  - `IListFeed<T>` supports `.Selection(...)`, but **NOT** supports `.ForEach(...)`!
- **States (`IState<T>`, `IListState<T>`)**: Stateful feeds with update capabilities
  - Replay current value + allow modifications
  - Use for data you usually would use Event based / INotifyPropertyChanged on. Bind from Xaml UI via `{Binding MyState, Mode=OneWay}` or with `{Binding MyState, Mode=TwoWay}`.
  - Initialize:
    - Value: `IState<int> Counter => State.Value(this, () => 0);` -> fills this with the Value `0` initially. Internally MVUX will set this: `Option<int>.Some(0)`
    - Empty: `IListState<Item> Items => ListState<Item>.Empty(this);` -> fills this with `Option<Item>.None()` initially.
      - **INVALID:** The `.Empty()` initializer is only available at `State<T>.Empty(this)` or `ListState<T>.Empty(this)` but is not at a non-typed `State.Empty(...)` / `ListState.Empty(...)`!
  - Selection of Items in a `IListState<T>` *OR* `IListFeed<T>`:
    - single or multi selection possible - make sure the UI element, e.g. ListView has SelectionMode set appropriately!
    - *Transfer* the selection to another `IState<T>` via:
      - `.Selection(...)`
      - Example:
        ```csharp
        public IListState<Person> People => ListState<Person>.Empty(this)
                                                            .Selection(OtherState);
        public IState<Person?> OtherState => State<Person>.Empty(this);
        ```
        Expect `OtherState` to be updated when:
        - You call from Model-Side `await People.TrySelectAsync(person)` 
        - The User selects an item in the bound UI control.
        You **MUST NOT** manually update `OtherState` either trought Model or Command + CommandParameter via UI except from explicitly Requested! Expect MVUX to handle updating and triggering `People.Selection(...)` automatically!
        - `MyListState.ClearSelection(...)` allows to clear the selection programmatically.
      - `.ForEach(...)` to react to selection changes (**NOT** for `IListFeed<T>`/`IFeed<T>`, only for `IListState<T>` / `IState<T>`):
        ```csharp
        public IListState<Person> People => ListState<Person>.Empty(this)
                                                            .Selection(SelectedPerson)
                                                            .ForEach(OnPersonSelected);
        public IState<Person> SelectedPerson => State<Person>.Empty(this);

        private Task OnPersonSelected(Person? person, CancellationToken ct)
        {
            // React to selection change here
        }
        ```
  - Update state values:
    - `State<T>`: (multiple overloads available! some of them are listed below)
      - `await CounterState.UpdateAsync(updater: _ => v + 1, ct);` (drop old value, set new)
      - `await PersonState.UpdateAsync(updater: p => p with { Name = "New Name" }, ct);` (with-record non-destructive syntax)
    - `ListState<T>` 
      - `await Members.UpdateAllAsync(match: item => item == replaceMember, updater: _ => modifiedName, ct: ct);`
      - `await PersonListState.UpdateItemAsync(match: p => p.Id == updatedPerson.Id, updater: p => updatedPerson, ct);`
        - **IMPORTANT:** `UpdateItemAsync(...)` is only available if the `T` type is a complex type like a `record` or `class`, which is implementing the `IKeyEquatable` or `IEquatable` interface! It is **NOT** available for primitive types like `int`, `string`, etc.!

**Attributes coming from `Uno.Extensions.Reactive`:**
- `FeedParameterAttribute`: allowes Methods in the Model to get Data from a Statefull property (Feed* or State*)
  - Example usage: `public async ValueTask RenameMemberAsync([FeedParameter(nameof(ModifiedMemberName))] string modName, CancellationToken ct)` - will provide the current value of the `IState<string>` Property `ModifiedMemberName` when the Method is called via Command from the UI, without needing to pass it as CommandParameter!

### Uno.Extensions.Navigation Architecture

**Identify the use of the Uno.Extensions.Navigation system with:**
- The `csproj` `<UnoFeatures>`-Entry: `<UnoFeatures>...Navigation...</UnoFeatures>`
- The presence of navigation registration code in `App.xaml.cs`:
  1. MVUX App: `.UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes)` / MVVM App: `.UseNavigation(RegisterRoutes)`
  2. `private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)` method defining Views and Routes
  3. Navigation startup at the end of `OnLaunched` with `Host = await builder.NavigateAsync<Shell>();`
  3. Optional, when using Toolkit Navigation Controls: `.UseToolkitNavigation()`

**Conventions and Patterns:**
- **Routes defined in `App.xaml.cs`** via `RegisterRoutes()` using `ViewRegistry` and `RouteRegistry`
- Navigation uses **`INavigator` service** (dependency-injected), **not `Frame.Navigate()`**
- Region-based navigation: `Frame`, `ContentControl`, `NavigationView`, `ContentDialog`, `Flyout`, `Popup`
- ViewMap associates Views with ViewModels: `new ViewMap<PageType, ModelType>()`
- DataViewMap for data-driven routes: `new DataViewMap<Page, Model, DataType>()`
- Nested routes: `new RouteMap("path", View: ..., Nested: [...], IsDefault: true, DependsOn: "parent")`
- Use `IRouteNotifier` in models to observe route changes

Navigation patterns:
```csharp
// In App.xaml.cs RegisterRoutes
views.Register(
  new ViewMap<MainPage, MainModel>(),
  new DataViewMap<DetailsPage, DetailsModel, Widget>()
);

routes.Register(
  new RouteMap("", View: views.FindByViewModel<ShellModel>(),
    Nested: [
      new ("Main", View: views.FindByViewModel<MainModel>(), IsDefault: true),
      new ("Details", View: views.FindByViewModel<DetailsModel>(), DependsOn: "Main")
    ]
  )
);

// In Model - inject INavigator
public partial record MainModel(INavigator Navigator)
{
  public async Task NavigateToDetails(Widget widget, CancellationToken ct)
    => await Navigator.NavigateDataAsync(this, widget, cancellation: ct);
}
```

**IMPORTANT:** Do not attempt to use `Shell` like a regular Page or View! It is the main navigation container. The sample above shows the default setup, where you are NOT allowed to modify anything in `Shell.xaml`, `Shell.xaml.cs` or the `ShellModel.cs`! All navigation happens in the nested routes below Shell.

### Configuration Pattern
- Load sections from `appsettings.json` using `.EmbeddedSource<App>().Section<TConfig>()`
- Keyed services for multiple code sample collections: `.AddKeyedSingletonCodeService("SampleName")`

### XAML Binding and Views

#### FeedView Control
- **FeedView** wraps async data with loading/error states
  - `Source="{Binding Feed}"` binds to IFeed/IState
  - `ValueTemplate` for successful data display
  - `ErrorTemplate` and `ProgressTemplate` for loading/error states
  - `{Binding Data}` accesses feed value in template
  - `{Binding Refresh}` command triggers feed refresh
  - FeedView `State` property is auto-set as DataContext for templates

#### Binding Best Practices
- The MVUX ViewModel is generated and provided at runtime as the `DataContext`
- **Prefer `{Binding}`** over `{x:Bind}` for MVUX feeds (runtime-reactive); `{x:Bind}` commonly leads to NullReferenceExceptions
- Access parent model in templates: `{Binding Parent.PropertyName}`
- Refresh commands: `{utu:AncestorBinding AncestorType=mvux:FeedView, Path=Refresh}`
- Use `{utu:AncestorBinding}` from Uno.Toolkit for parent access
- Centralize DataTemplates in ResourceDictionaries (see `Styles/GalleryTemplates.xaml`)
- Feeds are **awaitable** in code: `var data = await this.MyFeed;`

#### Views and Code-Behind (Critical Constraints)
- **Page constructors must have NO arguments** when using `<UnoFeatures>Navigation</UnoFeatures>` with Uno.Extensions. The navigation and DI system only instantiates Pages via the default parameterless constructor. Adding arguments (e.g., `MainPage(MainViewModel vm)` or `MainPage(IService svc)`) will cause build to fail.
- Do not inject or expect the MVUX-generated `*ViewModel` in a Page constructor
- Do not rely on `DataContextChanged` to grab the ViewModel early. The `INavigator` sets `DataContext` after the view initializes; accessing it early (or via TwoWay `{x:Bind}` with backing fields) will cause `NullReferenceException` and crash.
- Avoid creating backing properties/fields in code-behind that expect the ViewModel to exist during `InitializeComponent`
- Prefer pure XAML `{Binding}` to MVUX feeds/states exposed by the corresponding `*Model`

#### Selection with IListState/IListFeed (ListView/GridView)
- When binding a `ListView` or `GridView` to an `IListState<T>` or `IListFeed<T>` that uses the `.Selection(...)` operator, do **not** attach `Command`, `ItemClickCommand`, or `SelectionChanged` handlers on the control at the same time. Doing so prevents the MVUX selection pipeline from working.
- Correct pattern:
  - Model:
    ```csharp
    public partial record PeopleModel(IPeopleService Service)
    {
        public IListFeed<Person> People => ListFeed.Async(Service.GetPeopleAsync)
                                                    .Selection(SelectedPerson);
        public IState<Person> SelectedPerson => State<Person>.Empty(this);
    }
    ```
  - XAML:
    ```xml
    <mvux:FeedView Source="{Binding People}">
        <DataTemplate>
            <ListView ItemsSource="{Binding Data}" SelectionMode="Single"/>
        </DataTemplate>
    </mvux:FeedView>
    ```
  - **Warning:** Avoid setting `ItemClick`, `IsItemClickEnabled`, `ItemClickCommand`, or `SelectionChanged` on the list control when using `.Selection(...)`

### Localization
- Supported cultures in `appsettings.json`: `LocalizationConfiguration.Cultures`
- Inject `IStringLocalizer` for translated strings
- Documentation exists in `docs/articles/en/` and `docs/articles/de/`
- **German documentation style**: Use informal "Du" form (duzen) instead of formal "Sie" form. Address readers directly and personally (e.g., "du kannst", "dein Model", "wenn du"). German docs should feel like peer-to-peer communication, not formal instruction.

## Documentation Guidelines

### DocFX Markdown Best Practices

#### Code Snippets and Regions
- Use `<!-- #region RegionName -->` and `<!-- #endregion -->` in XAML files for DocFX code snippet references
- Reference snippets in markdown: `[!code-xaml[](../../../../src/ProjectName/File.xaml#RegionName)]`
- Use relative paths from the markdown file location (e.g., `../../../../src/...`) or tilde notation (`~/src/...`)
- Never use `#region-Name` or `<!--region: Name-->` syntax - these are incorrect
- Highlight specific lines: `[!code-xaml[](path#RegionName?highlight=15,18,22)]` where line numbers are relative to the region

#### Images and Attachments
- Store images in `docs/articles/.attachments/` folder
- Reference images using relative paths from the markdown file: `![](./.attachments/ImageName.png)`
- **Always verify image paths are correct** relative to the markdown file location, not from `docfx.json`
- DocFX resolves image paths relative to the markdown file itself, not from a central config

#### Formatting Rules
- **Never use emoji in documentation** (✅, ❌, etc.) - DocFX may not render them correctly
- Use plain markdown bullets, numbered lists, or bold text instead
- **Never add inline comments in code samples** - they may not render properly in DocFX
- Always place code explanations in separate text sections below code blocks
- **Tab heading indentation**: When using DocFX tabs (`#### [Tab Name](#tab/tabid)`), ensure the tab heading level is **one level deeper** than its parent section heading
  - Example: If the parent section is `### Section Name`, tab headings should be `#### [Tab Name](#tab/tabid)`
  - Example: If the parent section is `## Section Name`, tab headings should be `### [Tab Name](#tab/tabid)`
- **Markdown linting**: Pay attention to proper markdown formatting
  - Avoid extra blank lines between sections (use single blank line)
  - Ensure proper spacing around lists (blank line before and after list blocks)
  - No trailing whitespace at end of lines
  - Files should end with a single newline character
  - **MD028 - No blank lines between alert boxes**: When using consecutive alert boxes (e.g., `> [!WARNING]`, `> [!NOTE]`), do NOT add blank lines between them
    - Correct: Alert boxes directly after each other without blank lines
    - Incorrect: Blank line separating consecutive alert boxes
    - Example:
      ```markdown
      > [!WARNING]
      > First warning message
      > [!NOTE]
      > Following note without blank line between
      ```

#### Alert Boxes (Callouts)
Use alert boxes strategically to highlight important information without creating "rainbow docs":

- **When to use alert boxes:**
  - `> [!WARNING]` - Critical pitfalls that will cause errors or crashes (e.g., ListView ItemClickCommand conflicts)
  - `> [!TIP]` - Decision-making guidance or useful features (e.g., "When to use Value vs Async", FeedParameter benefits)
  - `> [!NOTE]` - Important design rationale or context (e.g., why button-triggered vs ForEach callbacks)
  - `> [!IMPORTANT]` - Essential requirements or prerequisites

- **When NOT to use alert boxes:**
  - For general explanations (use regular text)
  - For every bullet list (reserve for truly important items)
  - More than 3-4 alert boxes per tutorial page (avoid "rainbow docs")

- **Best practices:**
  - Limit to 3-4 strategically placed alert boxes per document
  - Use WARNING for errors/crashes, TIP for choices/features, NOTE for rationale
  - Convert existing bold text lists to alert boxes only if they represent critical decisions or warnings
  - Keep the content inside concise and focused

#### Tutorial Structure Pattern
When creating tutorial documentation, follow this consistent structure:

1. **Overview Section**
   - Brief description of what will be built
   - Bullet list of key features/learning goals
   - Explanation of why this pattern/approach is needed

2. **Prerequisites Section**
   - List required prior knowledge or tutorials that should be completed first
   - Link to previous tutorials in the learning path using xref links (e.g., "Complete [Tutorial Name](xref:uid-of-tutorial) first")
   - For "getting started" tutorials at the beginning of a new chapter: link to general app setup guides
   - Use language-appropriate links: English docs (`/en/`) link to English guides, German docs (`/de/`) link to German guides
   - Prefer `xref:` links for internal documentation references instead of relative paths
   - Example: "Before starting this tutorial, ensure you have completed [How to: Basic MVUX Setup](xref:howto-basic-mvux-setup)"

**Common Getting Started Docs to Link:**

- **Root-level basics** (in `docs/articles/en/` or `docs/articles/de/`):
  - `HowTo-Setup-DevelopmentEnvironment-*.md` (UID: `DevTKSS.Uno.Setup.DevelopmentEnvironment.en` or `.de`) - For first-time setup prerequisites
  - `HowTo-CreateApp-*.md` (UID: `DevTKSS.Uno.Setup.HowTo-CreateNewUnoApp.en` or `.de`) - For app creation fundamentals
  - `HowTo-Adding-New-Pages-*.md` (UID: `DevTKSS.Uno.Setup.HowTo-AddingNewPages.en` or `.de`) - For basic page creation
  - `HowTo-Adding-New-VM-Class-Record-*.md` (UID: `DevTKSS.Uno.Setup.HowTo-AddingNew-VM-Class-Record.en` or `.de`) - For MVUX Model creation basics
  - `HowTo-Using-DI-in-ctor-*.md` (UID: `DevTKSS.Uno.Setup.Using-DI-in-ctor.en` or `.de`) - For dependency injection fundamentals
  - `Introduction-*.md` (UID: `DevTKSS.Uno.SampleApps.Intro.en` or `.de`) - For general project introduction

- **Topic-specific getting started** (in subdirectories like `Navigation/`, `Mvux-StateManagement/`):
  - `Navigation/Extensions-Navigation-*.md` - For navigation system fundamentals
  - `Navigation/HowTo-RegisterRoutes-*.md` - For route registration basics
  - `Navigation/HowTo-UpgradeExistingApp-*.md` - For adding navigation to existing apps
  - Link to these when starting a tutorial within that specific topic area
  - Check the `uid:` field in each markdown file's front matter for the correct xref link

3. **Visual Reference** (if available)
   - Screenshot or diagram showing the end result
   - Place after prerequisites, before implementation details

4. **Model/Backend Setup**
   - Show the data layer first (Model, services, states)
   - Use tabbed sections for alternative approaches (e.g., `.Async()` vs `.Value()`)
   - Explain key elements with bullet points below code samples

5. **View/UI Implementation**
   - Show XAML/UI code after the model is defined
   - Highlight key binding lines in code snippets
   - Add warning callouts for common pitfalls
   - Explain bindings in bullet points

6. **Command/Logic Implementation**
   - Show methods that handle user interactions
   - Explain the "why" behind design decisions
   - Use bullet points to highlight key API usage

7. **Advanced Topics** (optional)
   - Attributes, optimization techniques, alternatives
   - Show code variations with explanations

8. **Summary Section**
   - Numbered list of what was demonstrated (no emojis)
   - Key takeaway or pattern reinforcement

This flow follows: **Prerequisites → See what we're building → Build the foundation → Connect the UI → Add behavior → Master advanced techniques**

## Build & Development

### Commands
```powershell
# Build with solution filters for specific apps
dotnet build src/DevTKSS.Uno.SampleApps-GalleryOnly.slnf
dotnet build src/DevTKSS.Uno.SampleApps-Tutorials.slnf

# Documentation (DocFX)
./docs/Build-Docs.ps1           # Build docs to _site
./docs/Clean-ApiDocs.ps1        # Clean generated API docs
```

### VS Code and Visual Studio notes
- In VS Code, keep `.vscode/tasks.json` in sync with solution changes (added/removed projects), or build tasks may fail. If projects change and tasks aren’t updated, update the tasks to point to the correct `.sln`/`.slnf` or project.
- In Visual Studio 2022+, verify `src/[ProjectName]/Properties/launchSettings.json` when adding/removing targets or tweaking profiles so F5/run profiles match current TFMs.

### Known Issues
1. **Windows target disabled** in MvuxGallery Issue [#15](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/issues/15): ResourcesDictionary import bug prevents building
2. **Theme changes** not reactive for ThemeResource styles Issue [#13](https://github.com/DevTKSS/DevTKSS.Uno.SampleApps/issues/13)
3. **DocFX source links** fail for `[!INCLUDE]` markup - uses workaround includes instead of redirects

#### Windows target and ResourceDictionaries
- Current limitation: the MvuxGallery app cannot build with the Windows target when using external `Styles/*.xaml` ResourceDictionary files (see repository issue about this limitation). If you need the Windows target and centralized DataTemplates, define them directly inside `App.xaml` instead of separate dictionary files.

### Warnings Suppressed
- `NU1507`: Multiple package sources with CPM
- `NETSDK1201`: RID won't create self-contained app
- `PRI257`: Default language (en) vs resources (en-us)

## Sample App Specifics

### MvuxGallery Features
- **FeedView + GridView/ListView** patterns with ItemOverlayTemplate
- Centralized DataTemplates in `Styles/GalleryTemplates.xaml`
- Code sample viewer using `IStorage.ReadPackageFileAsync()` from Assets
- TabBar navigation, NavigationView structure
- Custom extensions: `DevTKSS.Extensions.Uno.Storage` for line-range file reading

### XamlNavigationApp
- Tutorial-focused app for XAML markup navigation
- Demonstrates MVUX + Navigation combined patterns
- Bilingual README files: `ReadMe.en.md`, `ReadMe.de.md`

## Contributing Context
- Primary language: German (documentation available in EN/DE)
- Video tutorials on YouTube (German with English subtitles)
- Apache License 2.0
- Use GitHub Discussions for questions, Issues for bugs

## Uno Platform Context

### Important Notes
- This uses **Uno.Sdk** (not WinAppSDK/WinUI3)
- Targets: iOS/iPadOS, Android, macOS, Desktop, (Windows), Linux, WebAssembly
- Free C# and XAML Hot Reload support
