using Priv9.Cheat.Utils;
using Priv9.Cheat.Utils.Logging;
using Priv9.Cheat.Utils.Objects;
using Priv9.Cheat.Utils.Rendering.Animation;
using System.ComponentModel;
using System.Diagnostics;

namespace Priv9.Cheat.Screen.Hook
{
    internal partial class ScreenHook
    {
        private const string WND_NAME = "Counter-Strike 2";
        public static IntPtr HANDLE = Natives.FindWindow(null, WND_NAME);
        private static WindowRect RECT;
        private static readonly BackgroundWorker WORKER = new();

        public static void Start(Priv9Screen scr, Watermark watermark) 
        {
            // TODO: maybe use params Form[]?

            scr.TopMost = true;
            int startStyle = Natives.GetWindowLong(HANDLE, -20);
            _ = Natives.SetWindowLong(HANDLE, -20, startStyle | 0x8000 | 0x20); // min short val, 32

            WORKER.DoWork += Set;
            WORKER.RunWorkerAsync();

            void Set(object? sender, EventArgs e)
            {
                bool isCsRunning = true;
                while (isCsRunning)
                {
                    watermark.WatermarkText.Text = Watermark.GetWatermarkString();

                    Natives.GetWindowRect(HANDLE, out RECT);
                    _= Natives.SetWindowLong(HANDLE, -20, startStyle | 0x8000 | 0x20);

                    watermark.Size = new(RECT.Right - RECT.Left, RECT.Bottom - RECT.Top);
                    watermark.Left = RECT.Left + 4;
                    watermark.Top = RECT.Top + 4;
                    watermark.TopMost = true;

                    scr.Size = new(RECT.Right - RECT.Left, RECT.Bottom - RECT.Top);
                    scr.Left = RECT.Left + 225;
                    scr.Top = RECT.Top + 225;
                    
                    if (Process.GetProcessesByName("cs2").Length <= 0)
                    {
                        isCsRunning = false;
                        Priv9Screen.GetKbController().Dispose();
                        AnimationUtil.Animate(watermark, AnimationType.FadeOut, SmoothenMode.Linear, 1);
                        AnimationUtil.Animate(scr, AnimationType.FadeOut, SmoothenMode.Linear, 1);
                        Logger.Log("CS2 was closed or has crashed, aborting execution", LogLevel.Error);
                        Application.Exit();
                    }
                    
                    Thread.Sleep(1);
                }
            }
        }
    }
}
