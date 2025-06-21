using System;
using Microsoft.Extensions.DependencyInjection;

namespace WinForms.Extensions.DependencyInjection
{
    /// <summary>
    /// Singleton that exposes a global Dependency Injection service provider.
    /// Useful for resolving dependencies from anywhere in the application.
    /// </summary>
    public sealed class ServiceProviderGlobal
    {
        private static readonly Lazy<ServiceProviderGlobal> _instance =
            new(() => new ServiceProviderGlobal());

        /// <summary>
        /// Gets the singleton instance of the global service provider container.
        /// </summary>
        public static ServiceProviderGlobal Instance => _instance.Value;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance managed globally.
        /// </summary>
        public IServiceProvider Provider { get; private set; }

        private ServiceProviderGlobal() { }

        /// <summary>
        /// Initializes the global service provider. This method should only be called once, typically at application startup.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> instance to set as the global provider.</param>
        /// <exception cref="InvalidOperationException">Thrown if the global provider is already initialized.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the provided <paramref name="provider"/> is null.</exception>
        public void Initialize(IServiceProvider provider)
        {
            if (Provider != null)
                throw new InvalidOperationException("ServiceProviderGlobal is already initialized.");

            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
