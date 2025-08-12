namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;
/// <summary>
/// Provides extension methods for <see cref="IServiceProvider"/> to simplify service configuration and retrieval.
/// </summary>
public static class ServiceProviderExtensions
{
    /// <summary>
    /// Creates and configures an instance of <see cref="CodeSampleService"/> for the specified section.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="IServiceProvider"/> instance used to resolve required services.</param>
    /// <param name="sectionName">The name of the section for which the <see cref="CodeSampleService"/> should be configured.</param>
    /// <returns>A configured instance of <see cref="CodeSampleService"/>.</returns>
    /// <remarks>
    /// This extension method retrieves the necessary dependencies from the service provider and constructs a <see cref="CodeSampleService"/>
    /// instance tailored for the given section. It is useful for scenarios where code samples are organized by sections and require
    /// contextual configuration.
    /// </remarks>
    public static CodeSampleService ConfigureCodeSampleService(this IServiceProvider serviceProvider, string sectionName)
    {
        Console.WriteLine($"ServiceName: {sectionName}");
        var options = serviceProvider.GetRequiredService<IOptionsMonitor<CodeSampleOptions>>();
        var logger = serviceProvider.GetRequiredService<ILogger<CodeSampleService>>();
        var storage = serviceProvider.GetRequiredService<IStorage>();
        return new (sectionName, options, logger, storage);

    }
}
