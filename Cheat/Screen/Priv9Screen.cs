using Priv9.API.Module;
using Priv9.Cheat.Core.Managers;
using Priv9.Cheat.Screen.Builder;
using Priv9.Cheat.Screen.Hook;
using Priv9.Cheat.Utils.Rendering.Animation;
using System.Drawing.Text;

namespace Priv9.Cheat.Screen
{
    public partial class Priv9Screen : Form
    {
        private static Priv9Screen? INSTANCE;
        private static readonly System.Windows.Forms.Timer AnimationController = new();
        private static readonly KeyboardController KbController = new();

        public Priv9Screen() => Start();

        private void Start()
        {
            InitializeComponent();
            Category.HandleRegistries(this);
            Managers.Init();
            CheckForIllegalCrossThreadCalls = false; // <--- i don't like this...
            Opacity = 0.98D;
            INSTANCE = this;
            ScreenBuilder.GetInstance().Build(this);
            ScreenHook.Start(this, Watermark.GetInstance());
            KbController.Setup();
        }

        private void SetTextRenderingHint(object sender, PaintEventArgs e)
            => e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
        // ^^ doesn't remove antialias for some reason??

        public static Priv9Screen GetInstance() => INSTANCE ??= new();
        public static KeyboardController GetKbController() => KbController;

        private void OnFormLoad(object sender, EventArgs e)
        {
            Opacity = 0;
            AnimationUtil.Animate(this, AnimationType.FadeIn, SmoothenMode.Exponential, 6);
        }
    }
}
