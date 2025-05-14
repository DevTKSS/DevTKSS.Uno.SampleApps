
namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;

public interface ICodeSampleService
{
    /// <summary>
    /// Get the content of a specific code sample asynchronously.
    /// </summary>
    /// <param name="sampleID">The identifier of the sample.</param>
    /// <param name="ct">A cancellation token for the operation.</param>
    /// <returns>The content of the code sample.</returns>
    ValueTask<string> GetCodeSampleAsync(string sampleID,CancellationToken ct = default);

    /// <summary>
    /// Get a static collection of values for code sample options asynchronously.
    /// </summary>
    /// <param name="ct">A cancellation token for the operation.</param>
    /// <returns>A list of available code sample options.</returns>
    ValueTask<IImmutableList<string>> GetCodeSampleOptionsAsync(CancellationToken ct = default);


    /// <summary>
    /// Switches the current code sample to the specified option asynchronously.
    /// </summary>
    /// <param name="selectedSampleOption">The selected code sample option to switch to.</param>
    /// <param name="ct">A cancellation token for the operation.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> representing the asynchronous operation, with the content of the switched code sample as a string.
    /// </returns>
    ValueTask<string> SwitchCodeSampleAsync(string? selectedSampleOption, CancellationToken ct = default);
}
