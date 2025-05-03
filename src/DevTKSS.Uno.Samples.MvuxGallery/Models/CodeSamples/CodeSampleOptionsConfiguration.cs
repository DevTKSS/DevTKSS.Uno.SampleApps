namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public record CodeSampleOptionsConfiguration()
{
    public Dictionary<string, CodeSampleOption[]> Items { get; set; } = new();
}
[JsonSerializable(typeof(CodeSampleOptionsConfiguration))]
public partial class CodeSampleOptionsConfigurationContext : JsonSerializerContext
{
}
