using Priv9.API.Event.Listeners;
using Priv9.API.Setting;
using Priv9.API.Setting.Subtypes;
using Priv9.API.Setting.Subtypes.Helper;
using Priv9.Cheat.Screen;

namespace Priv9.API.Module
{
    internal abstract class ModuleImpl
    {
        private readonly string Name;
        private readonly Category Category;
        private bool Enabled, ListeningToBind;
        private ToggleMode TogglingMode = ToggleMode.Bind;
        private readonly List<IValue> Values = [];
        protected readonly List<IListener> Listeners = [];
        

        public readonly Setting<Bind> BindSet = new BindSetting.Builder()
            .WithName("Bind")
            .WithValue(Bind.Empty())
            .WithDescription("The key the feature is bound to.")
            .Build();

        public ModuleImpl(string Name, Category Category)
        {
            this.Name = Name;
            this.Category = Category;
            AddValues(BindSet);
        }

        public string GetName() => Name;
        public Category GetCategory() => Category;
        public virtual bool IsDangerous() => false;

        protected virtual void HandleEnable() { }
        protected virtual void HandleDisable() { }

        public void AddValues(params IValue[] ValuesIn)
        {
            foreach (IValue set in ValuesIn)
            {
                Values.Add(set);
            }
        }

        public List<IValue> GetValues() => Values;

        public void Disable()
        {
            Enabled = false;
            HandleDisable();
        }

        public void Enable()
        {
            Enabled = true;
            HandleEnable();
        }

        public bool IsOn() => Enabled;
        public bool IsListeningForBind() => ListeningToBind;
        public void SetListeningForBind(bool NewVal) 
        {
            ListeningToBind = NewVal;
            Priv9Screen.GetKbController().SetListening(this, NewVal);
        }

        protected void SetToggleMode(ToggleMode ModeIn) => TogglingMode = ModeIn;
        public ToggleMode GetToggleMode() => TogglingMode;

        public void Toggle()
        {
            if (IsOn())
                Disable();
            else
                Enable();
        }

        public enum ToggleMode
        {
            Toggle,
            Bind
        }
    }
}
