namespace Priv9.API.Setting.Subtypes.Helper
{
    public class SettingValueType(string typeName, Type actualType)
    {
        #region Code & Getters
        private readonly string _type = typeName;
        private readonly Type _actualType = actualType;
        public string Type { get { return _type; } }
        public Type ActualType { get { return _actualType; } }
        #endregion

        public static readonly SettingValueType Boolean = new("boolean", typeof(bool));
        public static readonly SettingValueType Numeric = new("numeric", typeof(double));
        public static readonly SettingValueType Bind = new("bind", typeof(Bind));
        public static readonly SettingValueType String = new("string", typeof(string));
        public static readonly SettingValueType Enumerator = new("enum", typeof(Enum));
    }
}
