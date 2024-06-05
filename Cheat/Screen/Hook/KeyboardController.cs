using Priv9.API.Module;
using Priv9.API.Setting.Subtypes.Helper;
using Priv9.Cheat.Core.Managers;
using Priv9.Cheat.Hacks.Other.Debug;
using Priv9.Cheat.Hacks.Other.Test;
using Priv9.Cheat.Screen.Hook.Util;
using Priv9.Cheat.Utils.Rendering.Animation;

namespace Priv9.Cheat.Screen.Hook
{
    public class KeyboardController : IDisposable
    {
        private KeyboardHook? _KeyboardHook;
        private bool _IsListeningForBind = false, _IsTyping = false;
        private ModuleImpl? _CurrentlyListening;

        public void Setup()
        {
            _KeyboardHook = new();
            _KeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object? sender, KeyboardEventArgs e)
        {
            Priv9Screen scr = Priv9Screen.GetInstance();

            if (e.KeyboardData.Key == Keys.Insert
                && e.KeyboardState == KeyboardHook.KeyboardState.KeyDown
                && _CurrentlyListening == null)
            {
                if (scr.Opacity > 0 && scr.Visible)
                {
                    AnimationUtil.Animate(scr, AnimationType.FadeOut, SmoothenMode.Linear, 6);
                    e.Handled = true;
                }
                else
                {
                    AnimationUtil.Animate(scr, AnimationType.FadeIn, SmoothenMode.Linear, 6);
                    e.Handled = true;
                }
                e.Handled = true;
            }

            if (IsListening() && _CurrentlyListening == Debug.GetInstance() 
                || _CurrentlyListening == Debug2.GetInstance())
            {
                if (e.KeyboardState == KeyboardHook.KeyboardState.KeyDown)
                {
                    if (e.KeyboardData.Key != Keys.Delete)
                    {
                        if (_CurrentlyListening == Debug.GetInstance())
                        {
                            Debug.GetInstance().BindSet.Set(Bind.Of(e.KeyboardData.Key));
                            Debug.GetInstance().SetListeningForBind(false);
                        }
                        else
                        {
                            Debug2.GetInstance().BindSet.Set(Bind.Of(e.KeyboardData.Key));
                            Debug2.GetInstance().SetListeningForBind(false);
                        }
                    }
                    else
                    {
                        if (_CurrentlyListening == Debug.GetInstance())
                        {
                            Debug.GetInstance().BindSet.Set(Bind.Of(Keys.None));
                            Debug.GetInstance().SetListeningForBind(false);
                        }
                        else
                        {
                            Debug2.GetInstance().BindSet.Set(Bind.Of(Keys.None));
                            Debug2.GetInstance().SetListeningForBind(false);
                        }
                    }
                }
            }

            foreach (ModuleImpl Mod in Managers.MODULES.GetAll())
            {
                if (e.KeyboardState == KeyboardHook.KeyboardState.KeyDown)
                {
                    if (IsListening() && _CurrentlyListening == Mod)
                    {
                        if (e.KeyboardData.Key != Keys.Delete)
                            Mod.BindSet.Set(Bind.Of(e.KeyboardData.Key));
                        else
                            Mod.BindSet.Set(Bind.Of(Keys.None));
                        Mod.SetListeningForBind(false);
                    }

                    if (Mod.BindSet.Get().GetKey() == e.KeyboardData.Key 
                        && !IsListening() 
                        && Mod.GetToggleMode() == ModuleImpl.ToggleMode.Bind)
                    {
                        Mod.Toggle();
                    }
                }
            }
        }

        internal void SetListening(ModuleImpl ModuleIn, bool ValueIn)
        {
            _CurrentlyListening = ValueIn ? ModuleIn : null;
            _IsListeningForBind = ValueIn;
        }

        public bool IsListening() => _IsListeningForBind;

        public void Dispose() => _KeyboardHook?.Dispose();
    }
}
