namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;

public record CodeSampleOptionsConfiguration()
{
    public Dictionary<string, CodeSampleOption> Samples { get; init; } = new();
}
[JsonSerializable(typeof(CodeSampleOptionsConfiguration))]
public partial class CodeSampleOptionsConfigurationContext : JsonSerializerContext
{
}

public record ListboardCodeSampleOptions : CodeSampleOptionsConfiguration
{
}

[JsonSerializable(typeof(ListboardCodeSampleOptions))]
public partial class ListboardCodeSampleOptionsContext : JsonSerializerContext
{
}

public record MainCodeSampleOptions : CodeSampleOptionsConfiguration
{
}

[JsonSerializable(typeof(MainCodeSampleOptions))]
public partial class MainCodeSampleOptionsContext : JsonSerializerContext
{
}

public record CounterCodeSampleOptions : CodeSampleOptionsConfiguration
{
}

[JsonSerializable(typeof(CounterCodeSampleOptions))]
public partial class CounterCodeSampleOptionsContext : JsonSerializerContext
{
}

public record SimpleCardsCodeSampleOptions : CodeSampleOptionsConfiguration
{
}
[JsonSerializable(typeof(SimpleCardsCodeSampleOptions))]
public partial class SimpleCardsCodeSampleOptionsContext : JsonSerializerContext
{
}

public record DashboardCodeSampleOptions : CodeSampleOptionsConfiguration
{
}

[JsonSerializable(typeof(DashboardCodeSampleOptions))]
public partial class DashboardCodeSampleOptionsContext : JsonSerializerContext
{
}
