using Priv9.API.Module;
using Priv9.Cheat.Utils.Logging;

namespace Priv9.Cheat.Hacks.Other.Test
{
    internal sealed class Debug2 : ModuleImpl
    {
        private static Debug2? INSTANCE;

        public Debug2() : base("Debug2", Category.Misc)
        {
            SetToggleMode(ToggleMode.Bind);
        }

        protected override void HandleEnable()
        {
            Logger.Log("Enabled debug2!");
        }

        protected override void HandleDisable()
        {
            Logger.Log("Disabled debug2!");
        }

        public override bool IsDangerous() => true;

        public static Debug2 GetInstance() => INSTANCE ??= INSTANCE = new();
    }
}
