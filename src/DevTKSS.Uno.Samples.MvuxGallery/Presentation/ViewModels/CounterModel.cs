
namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;

public partial record CounterModel
{
    private readonly ICodeSampleService<CounterSampleOptions> _sampleService;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly ILogger _logger;
    public CounterModel(
        IStringLocalizer stringLocalizer,
        ICodeSampleService<CounterSampleOptions> sampleService,
        ILogger<CounterModel> logger)
    {
        _logger = logger;
        _sampleService = sampleService;
        _stringLocalizer = stringLocalizer;
    }

    public IState<string> CounterTitle => State<string>.Value(this, () => _stringLocalizer["CounterTitle"]);

    public IState<Countable> Countable => State.Value(this, () => new Countable(0, 1));
    public ValueTask IncrementCounter()
        => Countable.UpdateAsync(c => c?.Increment());


    public IListFeed<string> CodeSampleOptions => ListFeed<string>.Async(_sampleService.GetCodeSampleOptionsAsync)
                                                                  .Selection(SelectedOption);
    public IState<string> SelectedOption => State<string>.Value(this, () => string.Empty)
                                                         .ForEach(SwitchCodeSampleAsync);
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);
    public async ValueTask SwitchCodeSampleAsync([FeedParameter(nameof(SelectedOption))] string? selectedOption, CancellationToken ct)
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
