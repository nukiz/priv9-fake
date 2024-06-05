namespace Priv9.Cheat.Core.Managers.Models
{
    /// <summary>
    /// Represents an Iterating Manager.
    /// These managers register something somewhere, for example, Modules.
    /// </summary>
    /// <typeparam name="T"> The type of the object to be registered. </typeparam>
    internal interface IRegistry<T>
    {
        void Init();
        void Add(T item);
        void Remove(T item, bool IsClosing);
        public List<T> GetAll();
        void Close();
    }
}
