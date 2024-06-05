using Priv9.API.Module;
using Priv9.API.Setting;
using Priv9.API.Setting.Subtypes;
using Priv9.Cheat.Utils.Logging;

namespace Priv9.Cheat.Hacks.Other.Debug
{
    internal sealed class Debug : ModuleImpl
    {
        private static Debug? INSTANCE;

        private readonly Setting<bool> BooleanTest = new BoolSetting.Builder()
            .WithName("test bool")
            .WithValue(true)
            .WithDescription("Test")
            .Build();

        public readonly Setting<int> NumberTest = new NumSetting<int>.Builder()
            .WithName("test slider")
            .WithDescription("Test")
            .WithBounds(0, 10)
            .WithValue(5)
            .Build();

        private readonly Setting<string> StringTest = new TextSetting.Builder()
            .WithName("test text")
            .WithDescription("Test")
            .WithValue("Test")
            .Build();

        public readonly Setting<Mode> ModeTest = new ModeSetting<Mode>.Builder()
            .WithName("test enum")
            .WithDescription("Test")
            .WithValue(Mode.Freestanding)
            .Build();

        public Debug() : base("Debug", Category.Misc)
        {
            SetToggleMode(ToggleMode.Toggle);
            AddValues(BooleanTest, NumberTest, StringTest, ModeTest);
        }

        protected override void HandleEnable()
        {
            Logger.Log("Enabled debug!");
        }

        protected override void HandleDisable()
        {
            Logger.Log("Disabled debug!");
        }

        public static Debug GetInstance() => INSTANCE ??= INSTANCE = new();
            
        public enum Mode
        {
            Freestanding,
            Always,
            Legacy
        }
    }
}
