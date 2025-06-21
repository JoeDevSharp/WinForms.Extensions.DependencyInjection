Claro, aquí tienes un README formal y profesional para tu módulo **WinForms.Extensions.DependencyInjection**:

---

# WinForms.Extensions.DependencyInjection

Integración avanzada de inyección de dependencias (DI) para aplicaciones Windows Forms. Basado en `Microsoft.Extensions.DependencyInjection`, pero adaptado y extendido para cubrir las necesidades específicas del desarrollo WinForms.

---

## Características principales

- Construcción sencilla del contenedor DI con soporte nativo para WinForms.
- Creación de formularios con ciclo de vida scoped para gestión automática de recursos.
- Inyección de dependencias vía constructor o propiedades marcadas con `[Inject]`.
- Interfaz `IInjectable` para inicialización tras inyección.
- Singleton global para acceso cómodo al contenedor de servicios.
- Facilita arquitecturas desacopladas y testables.
- Complementa y se integra perfectamente con los frameworks `Reactive` y `RouteManager`.

---

## Instalación

Agrega el paquete desde NuGet o compílalo desde la fuente.

```bash
dotnet add package WinForms.Extensions.DependencyInjection
```

---

## Uso básico

### Configuración en `Program.cs`

```csharp
using Microsoft.Extensions.DependencyInjection;
using WinForms.Extensions.DependencyInjection.Bootstrap;

var services = new ServiceCollection();

// Registra tus servicios y formularios aquí
services.AddSingleton<IMainService, MainService>();
services.AddTransient<MainForm>();
services.AddSingleton<FormFactory>();

var provider = services.BuildWinFormsServiceProvider();

ServiceProviderGlobal.Instance.Initialize(provider);

Application.Run(provider.GetRequiredService<MainForm>());
```

---

### Crear formularios con scope

```csharp
var formFactory = provider.GetRequiredService<FormFactory>();
var settingsForm = formFactory.CreateScopedForm<SettingsForm>();
settingsForm.Show();
```

---

### Inyección por propiedad con `[Inject]`

```csharp
public partial class MainForm : Form, IInjectable
{
    [Inject]
    public IMyService MyService { get; set; }

    public MainForm()
    {
        InitializeComponent();
        this.ResolveInjectedProperties(ServiceProviderGlobal.Instance.Provider);
    }

    public void OnInjected()
    {
        // Código tras inyección
    }
}
```

---

## API pública

- `ServiceProviderBuilder.BuildWinFormsServiceProvider(IServiceCollection)`: Construye el contenedor DI.
- `FormFactory.CreateScopedForm<T>()`: Crea un formulario con su propio scope.
- `[Inject]`: Atributo para marcar propiedades a inyectar.
- `ResolveInjectedProperties(this object, IServiceProvider)`: Extensión para inyección automática por propiedad.
- `IInjectable`: Interfaz para inicialización tras inyección.
- `ServiceProviderGlobal.Instance`: Singleton con acceso global al proveedor DI.

---

## Beneficios

Este módulo resuelve los problemas comunes de usar DI en WinForms, integrándose de forma natural con la plataforma y respetando sus paradigmas, facilitando la migración hacia arquitecturas más modernas y mantenibles.

---

## Repositorio y contribución

[https://github.com/JoeDevSharp/WinForms.Extensions.DependencyInjection](https://github.com/JoeDevSharp/WinForms.Extensions.DependencyInjection)

Contribuciones, issues y pull requests son bienvenidos.

---

¿Quieres que te prepare también ejemplos completos o una guía paso a paso para integrarlo en un proyecto real?
