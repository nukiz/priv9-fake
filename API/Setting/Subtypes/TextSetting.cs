using Priv9.API.Module;
using Priv9.API.Setting;
using Priv9.API.Setting.Subtypes.Helper;
using System.Diagnostics.CodeAnalysis;

namespace Priv9.API.Setting.Subtypes
{
    internal class TextSetting : Setting<string>
    {
        private TextSetting(string Name, string Initial) : base(Name, Initial) { }

        public override SettingValueType GetValueType() => SettingValueType.String;

        public class Builder : IBuilder<string, Builder>
        {
            private string? Name, Description, Value;

            public Builder WithName(string Name)
            {
                this.Name = Name;
                return this;
            }

            public Builder WithDescription(string Description)
            {
                this.Description = Description;
                return this;
            }

            public Builder WithValue(string Value)
            {
                this.Value = Value;
                return this;
            }

            public Setting<string> Build()
            {
                return new TextSetting(Name, Value)
                            .WithDescription(Description);
            }
        }
    }
}
