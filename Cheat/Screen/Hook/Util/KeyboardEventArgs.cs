using System.ComponentModel;

namespace Priv9.Cheat.Screen.Hook.Util
{
    internal class KeyboardEventArgs : HandledEventArgs
    {
        public KeyboardHook.KeyboardState KeyboardState { get; private set; }
        public KeyboardHook.LowLevelKeyboardInputEvent KeyboardData { get; private set; }

        public KeyboardEventArgs(KeyboardHook.LowLevelKeyboardInputEvent Data, KeyboardHook.KeyboardState State)
        {
            KeyboardData = Data;
            KeyboardState = State;
        }
    }
}
