namespace Priv9.API.Event.Listeners.Bus
{
    internal class Bus
    {
        public static readonly IEventBus INSTANCE = new EventBus();
    }
}
