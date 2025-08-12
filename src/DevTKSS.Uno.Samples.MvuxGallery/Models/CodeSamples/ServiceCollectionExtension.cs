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
    /// This method binds <see cref="CodeSampleOptions"/> to the configuration section "CodeSamples:{sectionName}" and registers
    /// a named singleton <see cref="ICodeSampleService"/> using the configured options.
    /// </remarks>
    public static IServiceCollection AddNamedConfiguredSingletonCodeService(this IServiceCollection services, string serviceName, string? sectionName = null)
    {
        Console.WriteLine($"ServiceName: {serviceName}");
        Console.WriteLine($"SectionName: {sectionName}");
       // services.AddOptions<CodeSampleOptions>(sectionName ?? serviceName).BindConfiguration<CodeSampleOptions>(sectionName ?? serviceName);
        services.AddNamedSingleton<ICodeSampleService, CodeSampleService>(serviceName, sp => sp
                .ConfigureCodeSampleService(sectionName ?? serviceName));

        return services;
    }
}
