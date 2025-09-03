namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public partial record CodeSampleService : ICodeSampleService
{ 
    private readonly IStorage _storage;
    private readonly ILogger<CodeSampleService> _logger;
   
    private CodeSampleOptions _options;
    
    public string Name { get; init; }

    public CodeSampleService(
        string name,
        IOptionsMonitor<CodeSampleOptions> options,
        ILogger<CodeSampleService> logger,
        IStorage storage)
    {
        _logger = logger;
        _storage = storage; 
        Name = name;
        _options = options.Get(Name);
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("CodeSampleService created for '{ServiceName}', loaded {SampleCount} samples", Name, _options.Samples.Length);
        }

        options.OnChange(UpdateOptions);
    }
    public void UpdateOptions(CodeSampleOptions newOptions, string? changedOption)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("CodeSampleOptions changed for {name}", changedOption);
        }
        if (changedOption == Name)
        {
            _logger.LogInformation("Updating CodeSampleOptions for {serviceName}", Name);
            _options = newOptions;
        }
    }

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
        await Task.Delay(1, ct);
        _logger.LogTrace("Collecting available code sample options for '{ServiceName}' from configuration...", Name );
        var sampleOptions = _options.Samples.Select(sample => sample.SampleID).ToImmutableList();
        
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            // Log available options
            _logger.LogDebug("Available Options for '{ServiceName}':\n{options}", Name, sampleOptions.JoinBy("," + Environment.NewLine));
        }
        else if (_logger.IsEnabled(LogLevel.Trace))
        {
            // Log available options
            _logger.LogTrace("Gathered {count} Options for '{ServiceName}'", sampleOptions.Count, Name);
        }

        return sampleOptions; 
    }

    public async ValueTask<string> GetCodeSampleAsync(string? sampleID, CancellationToken ct = default)
    {
        if (_options.Samples.FirstOrDefault(sample => sample.SampleID == sampleID) is CodeSample sampleOption)
        {
            if(_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace("Fetching Storage Data for Service '{service}', SampleID: {sampleID},\nDescription: {description},\nFilePath: {filePath},\nLineRanges: {lineRanges}",
                    Name,
                    sampleOption.SampleID,
                    sampleOption.Description,
                    sampleOption.FilePath,
                    sampleOption.LineRanges);
            }

            return await _storage.ReadLinesFromPackageFile(sampleOption.FilePath,sampleOption.LineRanges.Select(lr => (lr.Start, lr.End)));
        }

        _logger.LogError("Code sample with ID {sampleID} not found for service '{service}'", sampleID, Name);
        return string.Empty;
    }
}
