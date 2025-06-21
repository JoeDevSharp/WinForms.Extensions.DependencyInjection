using Microsoft.Extensions.DependencyInjection;
using System;

namespace WinForms.Extensions.DependencyInjection.Bootstrap
{
    /// <summary>
    /// Proporciona métodos de extensión para construir un ServiceProvider compatible con aplicaciones WinForms.
    /// </summary>
    public static class ServiceProviderBuilder
    {
        /// <summary>
        /// Construye un IServiceProvider listo para usarse en una aplicación WinForms.
        /// </summary>
        /// <param name="services">La colección de servicios a registrar.</param>
        /// <returns>Un IServiceProvider configurado.</returns>
        public static IServiceProvider BuildWinFormsServiceProvider(this IServiceCollection services)
        {
            // Aquí podrías registrar servicios específicos de WinForms si fuera necesario
            return services.BuildServiceProvider();
        }
    }
}