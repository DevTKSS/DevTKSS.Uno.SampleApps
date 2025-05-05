namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public record CodeSampleOption()
{
    public string FilePath { get; init; } = string.Empty;
    public List<(int Start, int End)> LineRanges { get; init; } = [];
}
[JsonSerializable(typeof(CodeSampleOption))]
public partial class CodeSampleOptionContext : JsonSerializerContext
{
}
