using System;
using Microsoft.Extensions.DependencyInjection;

namespace WinForms.Extensions.DependencyInjection
{
    /// <summary>
    /// Singleton para exponer globalmente el proveedor de servicios DI.
    /// Útil para resolver dependencias en cualquier parte de la aplicación.
    /// </summary>
    public sealed class ServiceProviderGlobal
    {
        private static readonly Lazy<ServiceProviderGlobal> _instance =
            new(() => new ServiceProviderGlobal());

        public static ServiceProviderGlobal Instance => _instance.Value;

        public IServiceProvider Provider { get; private set; }

        private ServiceProviderGlobal() { }

        /// <summary>
        /// Inicializa el proveedor global. Debe llamarse solo una vez, típicamente al inicio.
        /// </summary>
        public void Initialize(IServiceProvider provider)
        {
            if (Provider != null)
                throw new InvalidOperationException("ServiceProviderGlobal ya está inicializado.");

            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
