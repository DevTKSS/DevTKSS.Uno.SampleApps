namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;

public record CodeSampleOptions
{
    public CodeSample[] Samples { get; init; } = Array.Empty<CodeSample>();
}

