namespace Priv9.Cheat.Utils
{
    internal static class Instances
    {
        #region Colors
        /* Colors for the GUI. Not readonly for Theme compatibility. */
        public static readonly Color RIGHT_FADE = Color.FromArgb(2, 55, 45);
        public static readonly Color LEFT_FADE = Color.FromArgb(9, 69, 96);
        public static readonly Color DARK_GRAY = Color.FromArgb(36, 36, 36);
        public static readonly Color DANGEROUS_COLOR = Color.FromArgb(204, 255, 150);
        #endregion

        #region CS2 Process variables
        public static IntPtr CS2_HANDLE = IntPtr.Zero;
        public static int CS2_PID;
        #endregion
    }
}
