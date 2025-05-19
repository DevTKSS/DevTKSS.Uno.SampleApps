namespace DevTKSS.Uno.Samples.MvuxGallery.Presentation.ViewModels;
public partial record SimpleCardsModel
{
    private readonly ICodeSampleService<SimpleCardsSampleOptions> _sampleService;
    private readonly ILogger _logger;
    public SimpleCardsModel(
        ICodeSampleService<SimpleCardsSampleOptions> sampleService,
        ILogger<SimpleCardsModel> logger
        )
    {
        _logger = logger;
        _sampleService = sampleService;
    }


    #region CodeSample import
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
    #endregion
}
