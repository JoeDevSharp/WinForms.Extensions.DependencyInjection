using WinForms.Extensions.DependencyInjection;
using WinForms.Extensions.DependencyInjection.Attributes;
using WinForms.Extensions.DependencyInjection.Extensions;
using WinForms.Extensions.DependencyInjection.Interfaces;
using WinFormsAppTest.Interfaces;

namespace WinFormsAppTest
{
    public partial class MainForm : Form, IInjectable
    {
        private readonly IMyService _myServiceConstructor;

        [Inject]
        public IMyService MyServiceProperty { get; set; }

        public MainForm(IMyService myService)
        {
            InitializeComponent();
            _myServiceConstructor = myService;
            this.ResolveInjectedProperties(ServiceProviderGlobal.Instance.Provider);
        }
        public void OnInjected()
        {
            MessageBox.Show(_myServiceConstructor.GetWelcomeMessage() + " : " + MyServiceProperty.GetWelcomeMessage(), "Injection Test");
        }
    }
}
