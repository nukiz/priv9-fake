using Priv9.API.Setting.Subtypes.Helper;
using System.Diagnostics.CodeAnalysis;

namespace Priv9.API.Setting.Subtypes
{
    internal class ModeSetting<T> : Setting<T>, IValue where T : Enum
    {
        private ModeSetting(string Name, T Initial) : base(Name, Initial) { }
        public override SettingValueType GetValueType() => SettingValueType.Enumerator;

        public string[] GetAllValues()
        {
            return Get().GetType().GetEnumNames();
        }

        public class Builder : IBuilder<T, Builder>
        {
            [AllowNull] private string Name, Description;
            [AllowNull] private T Value;

            public Builder WithName(string Name)
            {
                this.Name = Name;
                return this;
            }

            public Builder WithValue(T Value)
            {
                this.Value = Value;
                return this;
            }

            public Builder WithDescription(string Description)
            {
                this.Description = Description;
                return this;
            }

            public Setting<T> Build()
            {
                return new ModeSetting<T>(Name, Value)
                            .WithDescription(Description);
            }
        }
    }
}
