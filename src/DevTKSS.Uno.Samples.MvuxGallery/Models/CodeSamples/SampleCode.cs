namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public record SampleCode()
{
    public string? CSharpCode { get; init; } = string.Empty;
    public string? XamlCode { get; init; } = string.Empty;
    public string[]? DataTemplates { get; init; } = [];
}
[JsonSerializable(typeof(SampleCode))]
public partial class SampleCodeContext : JsonSerializerContext 
{
}
