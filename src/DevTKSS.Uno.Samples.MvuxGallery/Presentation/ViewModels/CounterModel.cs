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

    public async Task ReloadCounterTitle()
    {
        await CounterTitle.SetAsync(_stringLocalizer["CounterTitle"]);
    }
}
