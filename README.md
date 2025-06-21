# WinForms.Extensions.DependencyInjection

Advanced Dependency Injection (DI) integration tailored for Windows Forms applications. Built on top of `Microsoft.Extensions.DependencyInjection`, but adapted and extended to address WinForms-specific development needs.

---

## Key Features

- Simplified DI container setup with native support for WinForms.
- Scoped form creation for automatic lifecycle and resource management.
- Dependency injection via constructor or `[Inject]`-marked properties.
- `IInjectable` interface for post-injection initialization.
- Global singleton access to the service provider.
- Enables clean, decoupled, and testable architecture.
- Seamless integration with companion frameworks `Reactive` and `RouteManager`.

---

## Installation

Add the package via NuGet or build from source:

```bash
dotnet add package WinForms.Extensions.DependencyInjection
```

---

## Quick Start

### Setup in `Program.cs`

```csharp
using Microsoft.Extensions.DependencyInjection;
using WinForms.Extensions.DependencyInjection.Bootstrap;

var services = new ServiceCollection();

// Register your services and forms here
services.AddSingleton<IMainService, MainService>();
services.AddTransient<MainForm>();
services.AddSingleton<FormFactory>();

var provider = services.BuildWinFormsServiceProvider();

ServiceProviderGlobal.Instance.Initialize(provider);

Application.Run(provider.GetRequiredService<MainForm>());
```

---

### Creating scoped forms

```csharp
var formFactory = provider.GetRequiredService<FormFactory>();
var settingsForm = formFactory.CreateScopedForm<SettingsForm>();
settingsForm.Show();
```

---

### Property injection with `[Inject]`

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
        // Initialization logic after injection
    }
}
```

---

## Public API

- `ServiceProviderBuilder.BuildWinFormsServiceProvider(IServiceCollection)`: Builds the DI container.
- `FormFactory.CreateScopedForm<T>()`: Creates a form with its own scoped lifetime.
- `[Inject]`: Attribute to mark properties for injection.
- `ResolveInjectedProperties(this object, IServiceProvider)`: Extension for automatic property injection.
- `IInjectable`: Interface for post-injection initialization callback.
- `ServiceProviderGlobal.Instance`: Singleton for global service provider access.

---

## Benefits

This module addresses common DI challenges in WinForms by integrating naturally with the platform and respecting its paradigms. It simplifies transitioning to modern, maintainable architectures.

---

## Repository and Contribution

[https://github.com/JoeDevSharp/WinForms.Extensions.DependencyInjection](https://github.com/JoeDevSharp/WinForms.Extensions.DependencyInjection)

Contributions, issues, and pull requests are welcome.
