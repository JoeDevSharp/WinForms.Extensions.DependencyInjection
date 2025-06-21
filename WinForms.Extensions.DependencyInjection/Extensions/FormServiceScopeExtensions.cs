using System.Reflection;
using WinForms.Extensions.DependencyInjection.Attributes;
using WinForms.Extensions.DependencyInjection.Interfaces;

namespace WinForms.Extensions.DependencyInjection.Extensions
{
    public static class PropertyInjectionExtensions
    {
        /// <summary>
        /// Inyecta las propiedades marcadas con [Inject] usando el contenedor DI.
        /// </summary>
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
