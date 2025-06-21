using System;

namespace WinForms.Extensions.DependencyInjection.Attributes
{
    /// <summary>
    /// Marca una propiedad para que sea inyectada automáticamente desde el contenedor DI.
    /// Útil cuando el constructor no puede usarse (por ejemplo, en formularios diseñados por WinForms Designer).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}
