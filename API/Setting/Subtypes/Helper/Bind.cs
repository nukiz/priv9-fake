namespace Priv9.API.Setting.Subtypes.Helper
{
    internal class Bind
    {
        private int KeyCode;
        private Keys Key;

        public Bind(Keys Key)
        {
            this.Key = Key;
        }

        public Bind(int KeyCode)
        {
            this.KeyCode = KeyCode;
            this.Key = (Keys) KeyCode;
        }

        public Keys GetKey() => Key;
        public int GetKeyCode() => KeyCode;
        public void SetKey(Keys key) => Key = key;
        public void SetKeyCode(int keyCode) => KeyCode = keyCode;

        public static Bind Empty() => new(Keys.None);
        public static Bind Of(Keys key) => new(key);
        public static Bind Of(int key) => new(key);
    }
}
