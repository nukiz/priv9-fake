using Priv9.API.Event.Models;

namespace Priv9.API.Event
{
    internal class EventListenable : ICancellable
    {
        private bool _Cancelled;

        public EventListenable() { }

        public void Cancel() => _Cancelled = true;

        public bool IsCancelled() => _Cancelled;
    }
}
