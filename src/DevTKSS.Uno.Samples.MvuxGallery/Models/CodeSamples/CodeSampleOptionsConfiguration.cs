namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public record CodeSampleOptionsConfiguration
{
    public Dictionary<string, CodeSampleOption> Samples { get; init; } = new();
}
[JsonSerializable(typeof(CodeSampleOptionsConfiguration))]
public partial class CodeSampleOptionsConfigurationContext : JsonSerializerContext
{
}
