using Priv9.API.Module;
using Priv9.API.Setting;

namespace Priv9.API.Setting.Subtypes.Helper
{
    /// <summary>
    /// Interface for all SettingBuilder patterns.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IBuilder<T, C> where C : IBuilder<T, C>
    {
        C WithName(string Name);
        C WithDescription(string Description);
        C WithValue(T Value);
        Setting<T> Build();
    }
}
