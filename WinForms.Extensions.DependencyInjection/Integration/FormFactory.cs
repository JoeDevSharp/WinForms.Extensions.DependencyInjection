using Microsoft.Extensions.DependencyInjection;

namespace WinForms.Extensions.DependencyInjection.Integration
{
    public class FormFactory
    {
        private readonly IServiceProvider _rootProvider;

        public FormFactory(IServiceProvider rootProvider)
        {
            _rootProvider = rootProvider ?? throw new ArgumentNullException(nameof(rootProvider));
        }

        /// <summary>
        /// Crea un formulario con su propio scope de dependencias.
        /// </summary>
        public T CreateScopedForm<T>() where T : Form
        {
            var scope = _rootProvider.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<T>();

            // Liberar el scope cuando el formulario se cierre
            form.FormClosed += (_, _) => scope.Dispose();

            return form;
        }
    }
}
