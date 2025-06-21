using Microsoft.Extensions.DependencyInjection;
using System;

namespace WinForms.Extensions.DependencyInjection.Bootstrap
{
    /// <summary>
    /// Provides extension methods to build an <see cref="IServiceProvider"/> 
    /// tailored for use in WinForms applications.
    /// </summary>
    public static class ServiceProviderBuilder
    {
        /// <summary>
        /// Builds an <see cref="IServiceProvider"/> ready to be used in a WinForms application.
        /// </summary>
        /// <param name="services">The service collection to register dependencies.</param>
        /// <returns>A configured <see cref="IServiceProvider"/> instance.</returns>
        public static IServiceProvider BuildWinFormsServiceProvider(this IServiceCollection services)
        {
            // Here you could add WinForms specific service registrations if needed
            return services.BuildServiceProvider();
        }
    }
}
