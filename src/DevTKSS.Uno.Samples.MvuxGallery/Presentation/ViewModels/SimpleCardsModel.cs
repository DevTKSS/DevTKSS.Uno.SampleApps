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
    public IState<string> CurrentCodeSample => State<string>.Value(this, () => string.Empty);
    public async Task GetCodeSampleAsync(object? content)
    {
        string? CodeSample = content?.ToString() switch
        {
            "XAML" => await _storage.ReadPackageFileAsync("Assets/Samples/SimpleCardSample.xaml.txt"),
            "C#" => await _storage.ReadPackageFileAsync("Assets/Samples/SimpleCardSample.cs.txt"),
            _ => string.Empty
        };

        await CurrentCodeSample.SetAsync(CodeSample);
    }
    #endregion
}
