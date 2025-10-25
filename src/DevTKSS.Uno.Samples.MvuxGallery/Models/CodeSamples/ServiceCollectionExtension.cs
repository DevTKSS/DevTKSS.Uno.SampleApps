namespace DevTKSS.Uno.Samples.MvuxGallery.Models.CodeSamples;

/// <summary>
/// Provides extension methods for <see cref="IServiceCollection"/> to register named and configured singleton services for code samples.
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Registers a named singleton <see cref="ICodeSampleService"/> with configuration binding for <see cref="CodeSampleOptions"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceName">The name of the service instance.</param>
    /// <param name="sectionName">The optional configuration section name. If not provided, <paramref name="serviceName"/> is used.</param>
    /// <returns>The <see cref="IServiceCollection"/> for chaining.</returns>
    /// <remarks>
    /// This method assumes configuration for the named <see cref="CodeSampleOptions"/> is provided (e.g., via UseConfiguration().Section&lt;T&gt;()).
    /// It registers a keyed singleton <see cref="ICodeSampleService"/> that consumes those named options.
    /// </remarks>
    public static IServiceCollection AddKeyedSingletonCodeService(this IServiceCollection services, string serviceName, string? sectionName = null)
    {
        var name = sectionName ?? serviceName;
        Console.WriteLine($"ServiceName (registration): {serviceName}");
        Console.WriteLine($"Effective section/name: {name}");

        // Register the keyed service instance that will consume the named options
        services.AddKeyedSingleton<ICodeSampleService>(serviceName, (serviceProvider,_) =>
            serviceProvider.ConfigureCodeSampleService(name));

        return services;
    }
}
