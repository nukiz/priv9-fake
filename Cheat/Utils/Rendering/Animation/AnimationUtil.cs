using Priv9.Cheat.Utils.Logging;
using Timer = System.Windows.Forms.Timer;

namespace Priv9.Cheat.Utils.Rendering.Animation
{
    internal static class AnimationUtil
    {
        private static Timer ANIMATION_TIMER = null!;

        public static void Animate(Form Target, AnimationType Animation, SmoothenMode Smoothen, int Interval)
        {
            if (ANIMATION_TIMER != null && ANIMATION_TIMER.Enabled) ANIMATION_TIMER.Dispose();
            ANIMATION_TIMER = new()
            {
                Interval = Interval
            };
            ANIMATION_TIMER.Tick += new EventHandler(DoAnimation);
            ANIMATION_TIMER.Start();

            void DoAnimation(object? sender, EventArgs e)
            {
                switch (Animation)
                {
                    case AnimationType.FadeIn:
                        if (Smoothen == SmoothenMode.Linear)
                        {
                            if (Target.Opacity < 0.98D)
                                Target.Opacity += 0.06D;
                            else
                                ANIMATION_TIMER.Stop();
                        }
                        else
                        {
                            ANIMATION_TIMER.Interval = 1;
                            if (Target.Opacity == 0)
                                Target.Opacity = 0.01;
                            else if (Target.Opacity > 0 && Target.Opacity < 0.98)
                                Target.Opacity += 0.008D + Math.Pow(2, -20 * Target.Opacity) / 6.5;
                            else
                                ANIMATION_TIMER.Stop();
                        }
                        break;
                    case AnimationType.FadeOut:
                        if (Smoothen == SmoothenMode.Linear)
                        {
                            if (Target.Opacity > 0)
                                Target.Opacity -= 0.06d;
                            else
                                ANIMATION_TIMER.Stop();
                        }
                        else
                        {
                            if (Target.Opacity > 0.9f)
                                Target.Opacity -= 0.01f;
                            else if (Target.Opacity > 0.09f)
                                Target.Opacity -= Target.Opacity * Target.Opacity;
                            else if (Target.Opacity == 0.0f)
                                ANIMATION_TIMER.Stop();
                        }
                        break; 
                }

                if (!ANIMATION_TIMER.Enabled)
                    ANIMATION_TIMER.Dispose();
            }
        }
    }
}
