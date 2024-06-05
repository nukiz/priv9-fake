namespace Priv9.Cheat.Core.Managers.Models.Exceptions
{
    [Serializable]
    internal sealed class UnregisterException : Exception
    {
        public UnregisterException(string message) : base(message) { }
    }
}
