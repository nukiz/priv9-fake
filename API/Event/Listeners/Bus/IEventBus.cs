namespace Priv9.API.Event.Listeners.Bus
{
    internal interface IEventBus
    {
        void Post(object Postable);
        void Subscribe(object Subscriber);
    }
}
