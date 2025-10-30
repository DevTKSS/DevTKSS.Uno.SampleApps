# Uno Platform MVUX Sample Apps - AI Coding Guide

## Project Context

This is a **German-localized** learning repository for **Uno Platform 6.3.28+** showcasing MVUX (Model-View-Update-eXtended) patterns, navigation, and Uno.Extensions. All apps use `.NET 9.0` with the `Uno.Sdk` (see `src/global.json`). Project context defaults to **Uno Platform, not MAUI**.

## Architecture & Patterns

### MVUX Models Convention
- **All models are `partial record` types** named `*Model` (e.g., `DashboardModel`, `MainModel`). These are not the ViewModels themselves.
- The bindable **ViewModel is auto-generated** from each `*Model` by the MVUX source generators at build time. You should never edit or depend on the generated files directly.
- Models use constructor injection for services (DI via Uno.Extensions.Hosting)
- **No `INotifyPropertyChanged`** - MVUX generates reactive bindings automatically
- Expose state via `IFeed<T>`, `IListFeed<T>`, `IState<T>`, or `IListState<T>` properties
- Models are **stateless** - focus on presentation logic, not state management

Generated ViewModels and analyzer notes:
- During test builds or when stepping through in the debugger, you may see messages about a missing `BindableAttribute` on models; these are expected with MVUX source generation and can be ignored.
- Do not add attributes or change patterns to “fix” these messages; the source generator handles the bindable surface. Never modify generated code under `obj/`.

Example pattern:
```csharp
public partial record DashboardModel
{
    public IListFeed<GalleryImage> GalleryImages => ListFeed.Async(_service.GetDataAsync);
    public IState<string> SelectedItem => State<string>.Value(this, () => "defaultValue")
                                                       .ForEach(SelectionChanged);
}
```

#### Feed vs State
- **Feeds (`IFeed<T>`, `IListFeed<T>`)**: Read-only async data streams from services
  - Stateless, reactive sequences similar to `IObservable<T>`
  - Use for data you won't edit (e.g., server responses)
  - Example: `IListFeed<Person> People => ListFeed.Async(_service.GetPeopleAsync);`

- **States (`IState<T>`, `IListState<T>`)**: Stateful feeds with update capabilities
  - Replay current value + allow modifications
  - Use for editable data with two-way binding
  - Example: `IState<int> Counter => State.Value(this, () => 0);`
  - Update via: `await CounterState.UpdateAsync(v => v + 1, ct);`

### Navigation Architecture
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

### Project Structure

> **Default structure:** Place all Views and Models in the `/Presentation` folder. Only if the app grows larger, add further subfolders (as seen in MvuxGallery) within `/Presentation` to keep the structure organized and concise.

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

## Key Conventions

### UnoFeatures in .csproj
Apps declare capabilities via `<UnoFeatures>`: Material, MVUX, Navigation, Hosting, Configuration, Localization, Serialization, Storage, ThemeService. **Do not manually add implicit package references** - they're managed by Uno.Sdk.

### Configuration Pattern
- Load sections from `appsettings.json` using `.EmbeddedSource<App>().Section<TConfig>()`
- Keyed services for multiple code sample collections: `.AddKeyedSingletonCodeService("SampleName")`
- Inject via `[FromKeyedServices("key")]` attribute

### XAML Binding

### Critical Troubleshooting: Never Remove `this.InitializeComponent()`
### Code Editing Rule: Never Remove or Replace Required Lines with Placeholders

> **🚨 DO NOT use `// ...existing code...` or any similar placeholder to remove or replace required framework or initialization lines (especially `this.InitializeComponent()`).**

- When editing, always preserve all required initialization and framework lines; do not replace them with comments, ellipses, or placeholders.
- If you are unsure about a line's necessity, **leave it unchanged** and investigate the real cause of the error.
- Never remove or replace `this.InitializeComponent()` or similar required lines, even if other inserted code would otherwise be correct.

> **🚨 ABSOLUTE RULE: Never remove `this.InitializeComponent()` from `App.xaml.cs` or any `*Page.xaml.cs` file.**

- If you see errors or build failures related to `this.InitializeComponent()`, **do NOT delete or comment out this line**. Removing it will break the app and prevent any XAML from loading.
- Instead, always check that:
  - The namespaces in your `*Page.xaml`, `*Page.xaml.cs`, and corresponding `*Model.cs` files are in sync and correct.
  - All Views and Models are properly registered in `App.xaml.cs` using the navigation/DI system.
  - There are no typos or mismatches in file/class names or XAML root element names.
- If you are troubleshooting DI/HostBuilder/service registration issues, **never fix by removing or altering `this.InitializeComponent()`**. The problem is almost always a registration, namespace, or XAML mismatch elsewhere.

> **If Copilot suggests removing or altering `this.InitializeComponent()`, this is always incorrect.**
- **Always use `{Binding}` (not `{x:Bind}`) when binding anything exposed by a `*Model`** (Feeds and States). The MVUX ViewModel is generated and provided at runtime as the `DataContext`; using `{x:Bind}` here commonly leads to NullReferenceExceptions.
- `FeedView` wraps async data: `<mvux:FeedView Source="{Binding GalleryImages}">` with `ValueTemplate`
- Access parent model in templates: `{Binding Parent.PropertyName}`
- Refresh commands: `{utu:AncestorBinding AncestorType=mvux:FeedView, Path=Refresh}`


#### Views and code-behind (no ViewModel ctor/fields, no Page constructor arguments)
- **Page constructors must have NO arguments** when the project uses `<UnoFeatures>...Navigation</UnoFeatures>` and navigation is registered in `App.xaml.cs` via Uno.Extensions. The navigation and DI system will only instantiate Pages using the default parameterless constructor. If you add any arguments (e.g., `MainPage(MainViewModel vm)` or `MainPage(IService svc)`), navigation will fail and the Page will not be created.
- Do not inject or expect the MVUX-generated `*ViewModel` in a Page constructor, and do not rely on `DataContextChanged` to grab it early. The `INavigator` sets the `DataContext` after the view initializes; trying to access it early (or via TwoWay `{x:Bind}` with backing fields) will cause `NullReferenceException` and crash.
- Avoid creating backing properties/fields in code-behind that expect the ViewModel to exist during `InitializeComponent`. Prefer pure XAML `{Binding}` to MVUX feeds/states exposed by the corresponding `*Model`.

#### Selection with IListState (ListView/GridView)
- When binding a `ListView` or `GridView` to an `IListState<T>` that uses the `.Selection(...)` operator, do **not** attach `Command`, `ItemClickCommand`, or `SelectionChanged` handlers on the control at the same time. Doing so prevents the MVUX selection pipeline from invoking the `.Selection(...)` operator.
- Correct pattern:
  - Model:
    ```csharp
    public partial record PeopleModel(IPeopleService Service)
    {
        public IListFeed<Person> People => ListFeed.Async(Service.GetPeopleAsync)
                                                    .Selection(SelectedPerson);
        public IState<Person?> SelectedPerson => State.Value(this, () => default(Person?));
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
  - Note: Avoid setting `ItemClick`, `IsItemClickEnabled`, `ItemClickCommand`, or `SelectionChanged` command bindings on the list control when using `.Selection(...)` on the bound `IListFeed/IListState`.

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
- Example:
  ```markdown
  ```csharp
  public IState<string> Name => State.Value(this, () => "default");
  ```
  
  This state holds the user's name with a default value.
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
- This uses **Uno.Sdk** (not WinAppSDK/WinUI directly)
- **Not MAUI** - uses .NET mobile bindings directly
- Targets: iOS/iPadOS, Android, macOS, Windows, Linux, WebAssembly
- Skia (canvas) and Native (native elements) renderers available
- Free C# and XAML Hot Reload support

### MVUX Specifics
- **FeedView control** wraps async data with loading/error states
  - `Source="{Binding Feed}"` binds to IFeed/IState
  - `ValueTemplate` for successful data display
  - `ErrorTemplate` and `ProgressTemplate` for states
  - `{Binding Data}` accesses feed value in template
  - `{Binding Refresh}` command triggers feed refresh
- Feeds are **awaitable**: `var data = await this.MyFeed;`
- BindableViewModel auto-generated with naming pattern `*Model` → `*ViewModel`
- Use `[ReactiveBindable]` attribute to customize code generation

### XAML Best Practices
- Prefer `{Binding}` over `{x:Bind}` for MVUX feeds (runtime-reactive)
- Use `{utu:AncestorBinding}` from Uno.Toolkit for parent access
- Centralize DataTemplates in ResourceDictionaries (see `Styles/GalleryTemplates.xaml`)
- FeedView `State` property auto-set as DataContext for templates
