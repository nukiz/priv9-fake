using Priv9.Cheat.Utils.Objects;
using Priv9.API.Event.Listeners.Types;
using Priv9.API.Module;

namespace Priv9.API.Event.Listeners.Bus
{
    internal class EventBus : IEventBus
    {
        private readonly List<IListener> Listeners = new();

        public void Post(object Postable)
        {
            foreach (IListener lst in Listeners)
            {
                if (((ModuleImpl) lst.GetModule()).IsOn()
                    && ObjectUtil.IsInstance(lst.GetObject(), Postable))
                {
                    ((BaseListener<ModuleImpl, EventListenable>) lst).Invoke((EventListenable)Postable); // will crash if bad
                }
            }
        }

        public void Subscribe(object Subscriber)
        {

        }

        public void AddListener(IListener listener)
        {
            Listeners.Add(listener);
        }
    }
}
