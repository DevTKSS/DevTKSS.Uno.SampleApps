namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
public record CodeSampleOption
{
    public string SampleID { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string FilePath { get; init; } = string.Empty;
    public Lines[] LineRanges { get; init; } = [];
}
public record Lines
{
    public int Start { get; init; }
    public int End { get; init; }
}

[JsonSerializable(typeof(CodeSampleOptionsConfiguration))]
[JsonSerializable(typeof(CodeSampleOption))]
[JsonSerializable(typeof(ListboardSampleOptions))]
[JsonSerializable(typeof(MainSampleOptions))]
[JsonSerializable(typeof(CounterSampleOptions))]
[JsonSerializable(typeof(SimpleCardsSampleOptions))]
[JsonSerializable(typeof(DashboardSampleOptions))]
public partial class CodeSampleOptionContext : JsonSerializerContext
{
}
