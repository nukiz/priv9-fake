using Priv9.Cheat.Utils.Objects;
using Priv9.API.Setting.Subtypes.Helper;
using System.Diagnostics.CodeAnalysis;

namespace Priv9.API.Setting
{
    public abstract class Setting<T> : IValue
    {
        [AllowNull] private readonly string Name;
        [AllowNull] private readonly T Initial;
        [AllowNull] private string Description;
        [NotNull] private T Value;

        public Setting(string Name, T Initial)
        {
            this.Name = Name;
            Value = this.Initial = Initial;
        }

        public string GetName() => Name;
        public T Get() => Value;
        public void Set(T Value) => this.Value = Value;

        public T GetInitial() => Initial;

        public Setting<T> WithDescription(string? Description)
        {
            this.Description = Description;
            return this;
        }

        /// <summary>
        /// Gets the description of the Setting.
        /// Always called when Value is not null, so no worries.
        /// </summary>
        /// <returns>The description.</returns>
        public string GetDescription() => Description
            ?? $"A setting. ({ObjectUtil.EnsureNotNull(Value.GetType().Name)})";

        public abstract SettingValueType GetValueType();
    }
}
