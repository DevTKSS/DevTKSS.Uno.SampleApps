namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;

public record CodeSampleOptionsConfiguration
{
    public CodeSampleOption[] Samples { get; init; } = Array.Empty<CodeSampleOption>();
}

public record ListboardSampleOptions : CodeSampleOptionsConfiguration
{
}

public record MainSampleOptions : CodeSampleOptionsConfiguration
{
}

public record CounterSampleOptions : CodeSampleOptionsConfiguration
{
}

public record SimpleCardsSampleOptions : CodeSampleOptionsConfiguration
{
}


public record DashboardSampleOptions : CodeSampleOptionsConfiguration
{
}

