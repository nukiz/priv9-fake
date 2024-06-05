using Priv9.Cheat.Utils;

namespace Priv9.Cheat.Screen
{
    public partial class Watermark : Form
    {
        public static Watermark? INSTANCE;
        // private DateTime _lastCheckTime = DateTime.Now;
        private long _frameCount = 0;

        public Watermark()
        {
            INSTANCE = this;
            CheckForIllegalCrossThreadCalls = false; // i don't particularly like this either
            InitializeComponent();
            Show();
        }

        /// <summary>
        /// Requires Memory access to get CS2's framerate I think
        /// </summary>
        internal void OnFpsUpdate() => Interlocked.Increment(ref _frameCount);

        internal static double GetFps()
        {
            /* TODO: 
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            long count = Interlocked.Exchange(ref _frameCount, 0);
            double fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            return fps;
            */
            Random rnd = new();
            return rnd.Next(200, 400);
        }

        public static string GetWatermarkString()
        {
            return $"priv9.net alpha | {DateTime.Now:MMM} {DateTime.Now:dd} {DateTime.Now:yyy} | fps: {GetFps()}";
        }

        public static Watermark GetInstance() => INSTANCE ??= new();

        private void WatermarkLoaded(object sender, EventArgs e)
        {
            int initial = Natives.GetWindowLong(Handle, -20);
            _ = Natives.SetWindowLong(Handle, -20, initial | 0x8000 | 0x20);
        }
    }
}
