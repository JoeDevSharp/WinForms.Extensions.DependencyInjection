using System;

namespace WinForms.Extensions.DependencyInjection.Attributes
{
    /// <summary>
    /// Marks a property for automatic injection from the DI container.
    /// Useful when constructor injection is not possible (e.g., in forms designed with the WinForms Designer).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}
