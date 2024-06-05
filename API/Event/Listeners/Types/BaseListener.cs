using Priv9.API.Module;

namespace Priv9.API.Event.Listeners.Types
{
    internal abstract class BaseListener<M, E> : IListener where E : EventListenable where M : ModuleImpl
    {
        private readonly E _ListeningObject;
        private readonly M _Module;

        public BaseListener(ModuleImpl Module, EventListenable Event)
        {
            _Module = (M)Module;
            _ListeningObject = (E)Event;
            // It's ensured that they're of the same Type in the Type parameter args.
        }

        public object GetObject() => _ListeningObject;
        public object GetModule() => _Module;
        public abstract void Invoke(E Event);
    }
}
