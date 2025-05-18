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
   
    public async ValueTask SwitchCodeSampleAsync(string? selectedOption,CancellationToken ct = default)
    {
        _logger.LogTrace("{method} called with parameter: {selectedOption}", nameof(SwitchCodeSampleAsync), selectedOption);

        if (string.IsNullOrWhiteSpace(selectedOption))
        {
            var options = await CodeSampleOptions;
            selectedOption = options.FirstOrDefault(string.Empty);
        }

        var sample = await _sampleService.GetCodeSampleAsync(selectedOption, ct);

        await CurrentCodeSample.SetAsync(sample, ct);
    }
    #endregion
}
