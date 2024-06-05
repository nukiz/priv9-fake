namespace Priv9.API.Event.Models
{
    internal interface ICancellable
    {
        bool IsCancelled();
        void Cancel();
    }
}
