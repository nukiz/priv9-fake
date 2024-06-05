using Priv9.API.Setting.Subtypes.Helper;

namespace Priv9.API.Setting.Subtypes
{
    internal class BindSetting : Setting<Bind>
    {
        private BindSetting(string Name, Bind Initial) : base(Name, Initial) { }
        public override SettingValueType GetValueType() => SettingValueType.Bind;

        public class Builder : IBuilder<Bind, Builder>
        {
            private string Name = null!, Description = null!;
            private Bind Value = null!;

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

            public Builder WithValue(Bind Value)
            {
                this.Value = Value;
                return this;
            }

            public Setting<Bind> Build()
            {
                return new BindSetting(Name, Value)
                            .WithDescription(Description);
            }
        }
    }
}
