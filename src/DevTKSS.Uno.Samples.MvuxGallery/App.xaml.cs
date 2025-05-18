using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uno.Resizetizer;

namespace DevTKSS.Uno.Samples.MvuxGallery;
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = this.CreateBuilder(args)
            // Add navigation support for toolkit controls such as TabBar and NavigationView
            .UseToolkitNavigation()
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseStorage()
                .UseLogging(configure: (context, logBuilder) =>
                {
                    // Configure log levels for different categories of logging
                    logBuilder
                        .SetMinimumLevel(
                            context.HostingEnvironment.IsDevelopment() ?
                                LogLevel.Information :
                                LogLevel.Warning)

                        // Default filters for core Uno Platform namespaces
                        .CoreLogLevel(LogLevel.Warning);

                    // Uno Platform namespace filter groups
                    // Uncomment individual methods to see more detailed logging

                    //// Generic Xaml events
                    //logBuilder.XamlLogLevel(LogLevel.Debug);
                    //// Layout specific messages
                    //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
                    //// Storage messages
                    //logBuilder.StorageLogLevel(LogLevel.Debug);
                    //// Binding related messages
                    logBuilder.XamlBindingLogLevel(LogLevel.Debug);
                    //// Binder memory references tracking
                    logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
                    //// DevServer and HotReload related
                    //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
                    //// Debug JS interop
                    //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);

                }, enableUnoLogging: true)
                .UseConfiguration(configure: configBuilder =>
                    configBuilder
                        .EmbeddedSource<App>()
                            .Section<AppConfig>()

                        .EmbeddedSource<App>("sampledata")
                            //.Section<DashboardSampleOptions>()
                            .Section<MainSampleOptions>()
                            .Section<ListboardSampleOptions>()
                            .Section<SimpleCardsSampleOptions>()
                            .Section<CounterSampleOptions>()
                )
                // Enable localization (see appsettings.json for supported languages)
                .UseLocalization()
                .ConfigureServices((context, services) =>
                    services
                        // TODO: Register your services

                        .AddSingleton<IGalleryImageService, GalleryImageService>()

                        .AddSingleton<ICodeSampleService<MainSampleOptions>, CodeSampleService<MainSampleOptions>>()
                        .AddSingleton<ICodeSampleService<ListboardSampleOptions>,CodeSampleService<ListboardSampleOptions>>()
                        .AddSingleton<ICodeSampleService<SimpleCardsSampleOptions>, CodeSampleService<SimpleCardsSampleOptions>>()
                        .AddSingleton<ICodeSampleService<CounterSampleOptions>, CodeSampleService<CounterSampleOptions>>()
                        //.AddSingleton<ICodeSampleService<DashboardSampleOptions>, CodeSampleService<DashboardSampleOptions>>()
                )
                .UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes)
                .UseSerialization((context, services) =>
                    services
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.CodeSampleOption)
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.LinesArray)
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.CodeSampleOptionsConfiguration)
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.Int32)
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.String)

                        // Following should get removed when NamedOptions can be used with DI Services and really getting values from the configuration
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.MainSampleOptions)
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.ListboardSampleOptions)
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.SimpleCardsSampleOptions)
                        .AddJsonTypeInfo(CodeSampleOptionContext.Default.CounterSampleOptions)
                        //.AddJsonTypeInfo(CodeSampleOptionContext.Default.DashboardSampleOptions)

                        .AddSingleton(new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                        )
            );
        MainWindow = builder.Window;
        
#if DEBUG
        MainWindow.UseStudio();
#endif
        MainWindow.SetWindowIcon();

        Host = await builder.NavigateAsync<Shell>();
    }

    private static void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(
            new ViewMap(ViewModel: typeof(ShellModel)),
            new ViewMap<MainPage, MainModel>(),
            new ViewMap<CounterPage, CounterModel>(),
            new ViewMap<DashboardPage, DashboardModel>(),
            new ViewMap<ListboardPage, ListboardModel>(),
            new ViewMap<SimpleCardsPage, SimpleCardsModel>()
        );

        routes.Register(
            new RouteMap("", View: views.FindByViewModel<ShellModel>(),
                Nested:
                [
                    new ("Main", View: views.FindByViewModel<MainModel>(), IsDefault:true,
                        Nested:
                        [
                            new ("Dashboard", View: views.FindByViewModel<DashboardModel>(),IsDefault: true),
                            new ("Listboard", View: views.FindByViewModel<ListboardModel>()),
                            new ("Counter", View: views.FindByViewModel<CounterModel>()),
                            new ("SimpleCards", View: views.FindByViewModel<SimpleCardsModel>()),
                        ]
                    ),

                ]
            )
        );
    }
}
