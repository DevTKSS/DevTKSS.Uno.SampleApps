namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;
public partial record MainModel
{
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IRouteNotifier _routeNotifier;
    private readonly ILogger _logger;
    private readonly ICodeSampleService<MainSampleOptions> _sampleService;

    public MainModel(
        IStringLocalizer stringLocalizer,
        IRouteNotifier routeNotifier,
        ILogger<MainModel> logger,
        ICodeSampleService<MainSampleOptions> sampleService)
    {
        _logger = logger;
        _routeNotifier = routeNotifier;
        _stringLocalizer = stringLocalizer;
        _routeNotifier.RouteChanged += routeNotifier_RouteChanged;
        _sampleService = sampleService;
    }

    public IState<string> CurrentNotifierRoute => State<string>.Value(this, () => string.Empty)
                                                               .ForEach(UpdateCurrentHeaderAsync);
    private async void routeNotifier_RouteChanged(object? sender, RouteChangedEventArgs e)
    {
        var RouteName = e.Navigator?.Route?.ToString() ?? string.Empty;
        _logger.LogDebug("Route was: {RouteAsString}", RouteName);
        await this.CurrentNotifierRoute.SetAsync(RouteName);
    }

    public IState<string> CurrentHeader => State<string>.Value(this, () => string.Empty);

    public async ValueTask UpdateCurrentHeaderAsync([FeedParameter(nameof(CurrentNotifierRoute))] string? currentNotifierRoute, CancellationToken ct = default)
    {
        _logger.LogDebug("CurrentNotifierRoute was: {CurrentNotifierRoute}", currentNotifierRoute);

        if (!string.IsNullOrWhiteSpace(currentNotifierRoute))
        {
            await CurrentHeader.SetAsync(_stringLocalizer[currentNotifierRoute + "Title"]);
        }
        else
        {
            _logger.LogTrace("{CurrentNotifierRoute} was empty, setting default header using 'WelcomeGreeting' Key",nameof(currentNotifierRoute));
            await CurrentHeader.SetAsync(_stringLocalizer["WelcomeGreeting"]);
        }
    }

    public IListFeed<string> CodeSampleOptions => ListFeed<string>.Async(_sampleService.GetCodeSampleOptionsAsync)
                                                                  .Selection(SelectedOption);
    public IState<string> SelectedOption => State<string>.Value(this, () => string.Empty)
                                                         .ForEach(SwitchCodeSampleAsync);
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);

    public async ValueTask SwitchCodeSampleAsync([FeedParameter(nameof(SelectedOption))] string? selectedOption, CancellationToken ct = default)
    {
        _logger.LogTrace("{methodName} called with selectedOption: '{SelectedOption}'", nameof(SwitchCodeSampleAsync), selectedOption);

        if (string.IsNullOrWhiteSpace(selectedOption))
        {
            _logger.LogTrace("selectedOption is null or whitespace. Attempting to get default from CodeSampleOptions.");
            var options = await CodeSampleOptions;
            selectedOption = options.FirstOrDefault(string.Empty);
            _logger.LogTrace("selectedOption updated to: '{SelectedOption}' after fetching options.", selectedOption);
        }
        string codeSample = await _sampleService.GetCodeSampleAsync(selectedOption, ct);
        _logger.LogTrace("Loaded code sample for option '{SelectedOption}': {CodeSample}", selectedOption, codeSample);
        await CurrentCodeSample.SetAsync(codeSample, ct);
    }
}

