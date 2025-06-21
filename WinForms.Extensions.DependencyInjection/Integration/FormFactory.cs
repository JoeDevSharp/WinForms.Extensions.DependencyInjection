using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace WinForms.Extensions.DependencyInjection.Integration
{
    /// <summary>
    /// Factory class responsible for creating WinForms with their own dependency injection scopes.
    /// </summary>
    public class FormFactory
    {
        private readonly IServiceProvider _rootProvider;

        /// <summary>
        /// Initializes a new instance of <see cref="FormFactory"/> with the root <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="rootProvider">The root service provider used to create scopes.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rootProvider"/> is null.</exception>
        public FormFactory(IServiceProvider rootProvider)
        {
            _rootProvider = rootProvider ?? throw new ArgumentNullException(nameof(rootProvider));
        }

        /// <summary>
        /// Creates a WinForms form of type <typeparamref name="T"/> with its own scoped service provider.
        /// The scope is automatically disposed when the form is closed.
        /// </summary>
        /// <typeparam name="T">The type of the form to create.</typeparam>
        /// <returns>An instance of the form with scoped dependencies.</returns>
        public T CreateScopedForm<T>() where T : Form
        {
            var scope = _rootProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<T>();

            // Dispose the scope when the form is closed
            form.FormClosed += (_, _) => scope.Dispose();

            return form;
        }
    }
}
