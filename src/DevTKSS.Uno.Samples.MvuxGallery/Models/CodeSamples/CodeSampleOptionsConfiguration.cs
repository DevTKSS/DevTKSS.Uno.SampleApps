namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public record CodeSampleOptionsConfiguration
{
//    public string Identifyer { get; init; } = string.Empty;
    public Dictionary<string, CodeSampleOption> Samples { get; set; } = new();
}
[JsonSerializable(typeof(CodeSampleOptionsConfiguration))]
public partial class CodeSampleOptionsConfigurationContext : JsonSerializerContext
{
}
