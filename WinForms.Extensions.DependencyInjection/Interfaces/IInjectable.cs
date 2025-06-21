namespace WinForms.Extensions.DependencyInjection.Interfaces
{
    /// <summary>
    /// Interfaz que puede implementar cualquier clase para recibir una llamada
    /// después de que se hayan resuelto las dependencias, ideal para inicializaciones.
    /// </summary>
    public interface IInjectable
    {
        /// <summary>
        /// Método llamado tras la inyección de dependencias.
        /// </summary>
        void OnInjected();
    }
}
