using Priv9.API.Setting.Subtypes.Helper;

namespace Priv9.API.Setting.Subtypes
{
    internal class BoolSetting : Setting<bool>, IValue
    {
        private BoolSetting(string Name, bool Value) : base(Name, Value) { }
        public override SettingValueType GetValueType() => SettingValueType.Boolean;

        public class Builder : IBuilder<bool, Builder>
        {
            private string Name = null!, Description = "A setting. (Boolean)"; 
            // Description initial value here, if not set it will remain as this
            private bool Value;
            // Booleans are never null, their default() is `false`

            public Builder WithDescription(string Description)
            {
                this.Description = Description;
                return this;
            }

            public Builder WithName(string Name)
            {
                this.Name = Name;
                return this;
            }

            public Builder WithValue(bool Value)
            {
                this.Value = Value;
                return this;
            }

            public Setting<bool> Build()
            {
                return new BoolSetting(Name, Value)
                                        .WithDescription(Description);
            }
        }
    }
}
