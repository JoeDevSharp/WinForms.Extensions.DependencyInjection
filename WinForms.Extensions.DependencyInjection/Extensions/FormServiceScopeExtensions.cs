using System;
using System.Linq;
using System.Reflection;
using WinForms.Extensions.DependencyInjection.Attributes;
using WinForms.Extensions.DependencyInjection.Interfaces;

namespace WinForms.Extensions.DependencyInjection.Extensions
{
    /// <summary>
    /// Provides extension methods for property injection in objects using the DI container.
    /// </summary>
    public static class PropertyInjectionExtensions
    {
        /// <summary>
        /// Injects properties marked with the <see cref="InjectAttribute"/> using the provided DI <see cref="IServiceProvider"/>.
        /// After injection, calls <see cref="IInjectable.OnInjected"/> if the target implements <see cref="IInjectable"/>.
        /// </summary>
        /// <param name="target">The target object whose properties will be injected.</param>
        /// <param name="provider">The service provider used to resolve dependencies.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="target"/> or <paramref name="provider"/> is null.</exception>
        public static void ResolveInjectedProperties(this object target, IServiceProvider provider)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            var properties = target.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(p => p.IsDefined(typeof(InjectAttribute), true) && p.CanWrite);

            foreach (var prop in properties)
            {
                var service = provider.GetService(prop.PropertyType);
                if (service != null)
                {
                    prop.SetValue(target, service);
                }
            }

            if (target is IInjectable injectable)
            {
                injectable.OnInjected();
            }
        }
    }
}
