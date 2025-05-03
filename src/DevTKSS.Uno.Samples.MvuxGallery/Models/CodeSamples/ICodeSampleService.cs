
namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;

public interface ICodeSampleService
{
    ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync<TOwner>(TOwner owner, CancellationToken ct = default) where TOwner : class;
    Task<string> GetCodeSampleAsync(string callerID, string sampleID);
    ValueTask<ImmutableList<string>> GetCodeSampleOptions(string callerID, CancellationToken ct = default);
    ValueTask<string> SwitchCodeSampleAsync(string? choice, CancellationToken ct = default);
}
