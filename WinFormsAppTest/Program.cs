using Microsoft.Extensions.DependencyInjection;
using WinForms.Extensions.DependencyInjection;
using WinForms.Extensions.DependencyInjection.Bootstrap;
using WinForms.Extensions.DependencyInjection.Integration;
using WinFormsAppTest.Interfaces;
using WinFormsAppTest.Services;

namespace WinFormsAppTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            // Registrar servicios
            services.AddSingleton<IMyService, MyService>();
            services.AddTransient<MainForm>();
            services.AddSingleton<FormFactory>();

            var provider = services.BuildWinFormsServiceProvider();
            ServiceProviderGlobal.Instance.Initialize(provider);

            Application.Run(provider.GetRequiredService<MainForm>());
        }
    }
}