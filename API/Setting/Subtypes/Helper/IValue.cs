namespace Priv9.API.Setting.Subtypes.Helper
{
    /// <summary>
    /// Interface for generalization of Settings. (CHINESE, TODO FIX)
    /// </summary>
    public interface IValue
    {
        string GetName();
        SettingValueType GetValueType();
    }
}
