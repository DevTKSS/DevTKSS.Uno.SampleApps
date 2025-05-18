namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public partial record CodeSampleService<SampleOptions> : ICodeSampleService<SampleOptions>
    where SampleOptions : CodeSampleOptionsConfiguration
{
    public CodeSampleService(
        IOptions<SampleOptions> options,
        ILogger<CodeSampleService<SampleOptions>> logger,
        IStorage storage)
    {
        _options = options.Value;
        _logger = logger;
        _storage = storage;
        if (_logger.IsEnabled(LogLevel.Trace))
        {
            _logger.LogTrace("Initializing options for {serviceName}...",
                nameof(CodeSampleService<SampleOptions>));
        }
        if (_logger.IsEnabled(LogLevel.Debug))
        { 
            // Log LineRanges for each sample option
            foreach (var sample in _options.Samples)
            {
                _logger.LogDebug("\tSampleID: {sampleID},\nDescription: {description},\nFilePath: {filePath},\nLineRanges: {lineRanges}",
                    sample.SampleID,
                    sample.Description,
                    sample.FilePath,
                    sample.LineRanges);
                                 
            }
        }
        else if (_logger.IsEnabled(LogLevel.Trace))
        {
            _logger.LogTrace("Gathered {count} Options", _options.Samples.Length);
        }
    }

    private readonly IStorage _storage;
    private readonly ILogger<CodeSampleService<SampleOptions>> _logger;
    private readonly SampleOptions _options;

    /// <summary>
    /// Get a static Collection of Values for <see cref="CodeSampleOptions"/>
    /// </summary>
    /// <param name="ct">
    /// A CancellationToken to make it compileable
    /// <remarks>
    /// since `ListFeed.Async` requires a CancellationToken even if Uno Documentation remarks this parameter to be optional.<br/>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0411?f1url=%3FappId%3Droslyn%26k%3Dk(CS0411)">CS0411</see><br/>
    /// <br/>
    /// adding then the type string or IImmutableList<string> to the ListFeed like `ListFeed<string>.Async(...)`,
    /// or to the Async Extension itself like `ListFeed.Async<IImutableList<string>` results in a type mismatch.<br/>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1503?f1url=%3FappId%3Droslyn%26k%3Dk(CS1503)">CS1503</see>
    /// </remarks>
    /// <returns>An awaitable <see cref="ValueTask{TResult}"/> providing a <see cref="ImmutableList{T}"/> of <see langword="string"/> with the Sample Names to select from</returns>
    public async ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync(CancellationToken ct = default)
    {
        await Task.Delay(1);
        _logger.LogTrace("Collecting available code sample options from appsettings.sampledata.json...");
        var sampleOptions = _options.Samples.Select(sample => sample.SampleID).ToImmutableList();
        
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            // Log available options
            _logger.LogDebug("Available Options:\n{options}", sampleOptions.JoinBy("," + Environment.NewLine));
        }
        else if (_logger.IsEnabled(LogLevel.Trace))
        {
            // Log available options
            _logger.LogTrace("Gathered {count} Options", sampleOptions.Count);
        }

        return sampleOptions; 
    }

    public async ValueTask<string> GetCodeSampleAsync(string? sampleID, CancellationToken ct = default)
    {
        if (_options.Samples.FirstOrDefault(sample => sample.SampleID == sampleID) is CodeSampleOption sampleOption)
        {
            if(_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace("Fetching Storage Data for SampleID: {sampleID},\nDescription: {description},\nFilePath: {filePath},\nLineRanges: {lineRanges}",
                    sampleOption.SampleID,
                    sampleOption.Description,
                    sampleOption.FilePath,
                    sampleOption.LineRanges);
            }

            return await _storage.ReadLinesFromPackageFile(sampleOption.FilePath,sampleOption.LineRanges.Select(lr => (lr.Start, lr.End)));
        }

        _logger.LogError("Code sample with ID {sampleID} not found", sampleID);
        return string.Empty;
    }
}
