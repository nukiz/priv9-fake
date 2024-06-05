using Priv9.API.Setting.Subtypes.Helper;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Priv9.API.Setting.Subtypes
{
    internal class NumSetting<T> 
        : Setting<T>, IValue 
            where T : INumber<T>
    {
        private readonly T Min, Max;

        public override SettingValueType GetValueType() => SettingValueType.Numeric;

        private NumSetting(string Name, T Initial, T Min, T Max) : base(Name, Initial)
        {
            this.Min = Min;
            this.Max = Max;
        }

        public T GetMin() => Min;
        public T GetMax() => Max;
        public bool IsInBounds() => Get() >= Min && Get() <= Max;

        public class Builder : IBuilder<T, Builder>
        {
            [AllowNull] private string Name, Description;
            [AllowNull] private T Value, Min, Max;

            public Builder WithName(string Name)
            {
                this.Name = Name;
                return this;
            }

            public Builder WithBounds(T Min, T Max)
            {
                this.Min = Min;
                this.Max = Max;
                return this;
            }

            public Builder WithValue(T Value)
            {
                this.Value = Value >= Min && Value <= Max && Min != null && Max != null ? Value : throw new ArgumentOutOfRangeException("NumberSetting", "Everest: NumberSetting doesn't have bounds or its value exceeds them!");
                return this;
            }

            public Builder WithDescription(string Description)
            {
                this.Description = Description;
                return this;
            }

            public Setting<T> Build()
            {
                return new NumSetting<T>(Name, Value, Min, Max)
                            .WithDescription(Description);
            }
        }
    }
}
