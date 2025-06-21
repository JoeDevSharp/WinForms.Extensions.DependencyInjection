using WinFormsAppTest.Interfaces;

namespace WinFormsAppTest.Services
{
    public class MyService : IMyService
    {
        public string GetWelcomeMessage() => "Hello from MyService!";    
    }
}
