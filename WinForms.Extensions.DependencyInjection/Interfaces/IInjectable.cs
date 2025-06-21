namespace WinForms.Extensions.DependencyInjection.Interfaces
{
    /// <summary>
    /// Interface that can be implemented by any class to receive a callback
    /// after its dependencies have been resolved. Ideal for performing initialization logic.
    /// </summary>
    public interface IInjectable
    {
        /// <summary>
        /// Method invoked after dependency injection has been completed.
        /// </summary>
        void OnInjected();
    }
}
