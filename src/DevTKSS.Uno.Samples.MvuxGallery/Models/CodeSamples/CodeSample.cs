namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public record CodeSample
{
    public string SampleID { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string FilePath { get; init; } = string.Empty;
    public Lines[] LineRanges { get; init; } = [];
}

[JsonSerializable(typeof(CodeSampleOptions))]
[JsonSerializable(typeof(CodeSample))]
[JsonSerializable(typeof(Lines))]
[JsonSerializable(typeof(CodeSample[]))]
[JsonSerializable(typeof(IEnumerable<CodeSample>))]
public partial class CodeSampleOptionsContext : JsonSerializerContext
{
}
