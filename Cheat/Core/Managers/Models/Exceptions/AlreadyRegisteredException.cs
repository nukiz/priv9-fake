namespace Priv9.Cheat.Core.Managers.Models.Exceptions
{
    [Serializable]
    internal sealed class AlreadyRegisteredException : Exception
    {
        public AlreadyRegisteredException(string message) : base(message) { }
    }
}
