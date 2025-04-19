namespace UnoHotDesignApp1.Presentation.Models;
public partial record SimpleCardsModel
{
    private readonly IStorage _storage;
    public SimpleCardsModel(IStorage storage)
    {
        _storage = storage;
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
