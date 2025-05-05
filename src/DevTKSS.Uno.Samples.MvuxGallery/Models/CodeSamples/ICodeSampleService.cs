
namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;

public interface ICodeSampleService
{

    /// <summary>
    /// Get the content of a specific code sample asynchronously.
    /// </summary>
    /// <param name="callerID">The identifier of the caller.</param>
    /// <param name="sampleID">The identifier of the sample.</param>
    /// <returns>The content of the code sample.</returns>
    ValueTask<string> GetCodeSampleAsync(string sampleID,CancellationToken ct = default);

    /// <summary>
    /// Get a static collection of values for code sample options asynchronously.
    /// </summary>
    /// <param name="owner">The owner model to filter options.</param>
    /// <param name="ct">A cancellation token for the operation.</param>
    /// <returns>A list of available code sample options.</returns>
    ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync(CancellationToken ct = default);

}
